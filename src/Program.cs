using LevelScriptEditor.Forms;
using System;
using Gtk;
using static Gtk.Application;


namespace LevelScriptEditor
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Init();

			MainWindow.Instance.ShowAll();
			
			Run();
		}
	}
}
