using System;
using System.Diagnostics;

namespace ROM.SoE.Scripting.Bases
{
	/// <summary>
	/// Base class for Scripting routines
	/// </summary>
	internal abstract class ScriptingBase
	{
		protected static readonly Random Random = new();

		protected void Dialog(string text) => Debug.Print($"DIALOG: {text}");
		protected void PlaySound(int id) => Debug.Print($"PLAY SOUND: {id}");
		protected UInt16 SelectionDialog(params string[] texts)
		{
			Debug.Print("DIALOG: ");

			foreach (var text in texts)
				Debug.Print(Environment.NewLine + text);

			return default;
		}
	}
}