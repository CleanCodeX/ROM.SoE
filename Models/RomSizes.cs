// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable PossibleLossOfFraction

namespace ROM.SoE.Models
{
	/// <summary>
	/// Known sizes of SoE's ROM buffer
	/// </summary>
	public static class RomSizes
	{
		/// Size of the ROM file
		public const int Size = 1024 * 1024 * 3;

		public static readonly bool IsValid = All == Size;

		#region DO NOT RENAME - Accessed by Reflection

		public const int All = Size; /* temporary */
		public const int AllUnknown = Size; /* temporary */
		public const int AllKnown = Size - AllUnknown;

		public const double UnknownPercentage = AllUnknown * 100D / Size;
		public const double KnownPercentage = AllKnown * 100D / Size;

		#endregion
	}
}