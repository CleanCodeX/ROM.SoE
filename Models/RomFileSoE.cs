using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Common.Shared.Min.Helpers;
using ROM.Models;
using ROM.SoE.Helpers;
using ROM.SoE.Models.Structs;
using SoE.Models.Enums;

namespace ROM.SoE.Models
{
	/// <summary>
	/// ROM file implementation for <see cref="RomSoE"/>
	/// </summary>
	public class RomFileSoE : RomFile<RomSoE>
	{
		/// <summary>
		/// Checksum validation status of every game
		/// </summary>
		private bool _isValid;

		/// <summary>
		/// The ROM's file region 
		/// </summary>
		public GameRegion GameRegion { get; }

		/// <summary>
		/// Creates an instance of <see cref="RomFileSoE" />
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="region">The ROM's file region</param>
		public RomFileSoE(byte[] buffer, GameRegion region) : base(buffer) => GameRegion = region;

		/// <summary>
		/// Creates an instance of <see cref="RomFileSoE" />
		/// </summary>
		/// <param name="stream">The (opened) stream from which the ROM buffer and ROM structure will be loaded</param>
		/// <param name="region">The ROM's file region</param>
		public RomFileSoE(Stream stream, GameRegion region) : base(stream) => GameRegion = region;

		protected override void OnLoading() => SizeChecks();

		private void SizeChecks()
		{
			Debug.Assert(RomSizes.IsValid);

			StructSizeValidator.Validate();

			Requires.Equal(Marshal.SizeOf<RomSoE>(), RomSizes.Size, nameof(Size));
		}

		/// <summary>
		/// Returns if a save slot index itself is valid and the game's checksum is correct
		/// </summary>
		/// <returns>Returns true if the save slot index itself is valid and the checksum for that game is</returns>
		public override bool IsValid() => _isValid;

		/// <summary>
		/// Loads the entire ROM buffer and structure from a stream
		/// </summary>
		/// <param name="stream">The (openned) stream which holds the blob buffer</param>
		public override void Load(Stream stream)
		{
			base.Load(stream);

			var fileChecksum = GetChecksum();

			//var calculatedChecksum = ChecksumHelper.CalcChecksum(Buffer, GameRegion);
			//_isValid = fileChecksum == calculatedChecksum;
		}

		//protected override void OnSaving() => SetChecksum(ChecksumHelper.CalcChecksum(Buffer, GameRegion));

		/// <summary>
		/// Gets the checksum for a save slot index
		/// </summary>
		/// <returns>The checksum for the given save slot index</returns>
		public virtual ushort GetChecksum() => BitConverter.ToUInt16(Buffer, 0);

		/// <summary>
		/// Sets the checksum for the given save slot index
		/// </summary>
		/// <param name="checksum">The checksum to be set</param>
		public virtual void SetChecksum(ushort checksum)
		{
			var bytes = BitConverter.GetBytes(checksum);

			bytes.CopyTo(Buffer, 0);
		}
	}
}