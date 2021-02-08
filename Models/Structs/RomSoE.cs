using System.Runtime.InteropServices;
using IO.Extensions;

namespace ROM.SoE.Models.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct RomSoE
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RomSizes.Size)]
		public byte[] Unknown1; // Offset [0] (3 MiB)

		public override string ToString() => this.Format();
	}
}