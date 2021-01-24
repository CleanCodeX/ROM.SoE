// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable PossibleLossOfFraction

namespace ROM.SoE.Models
{
	/// <summary>
	/// Known sizes of SoE's ROM buffer
	/// </summary>
	public class RomSizes
	{
		/// Size of the ROM file
		public const int All = 1024 ^ 3;

		public static readonly bool IsValid = All == (1024 ^ 3);
	}
}