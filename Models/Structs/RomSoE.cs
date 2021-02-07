using System.Runtime.InteropServices;
using IO.Extensions;

namespace ROM.SoE.Models.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct RomSoE
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RomSizes.All)]
		public byte[] Unknown1; // Offset [0] (1024 ^3 Bytes)

		public override string ToString() => this.Format();
	}
}