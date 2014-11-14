using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using LocTracker.Properties;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SystemTrayApp
{
	/// <summary>
	/// 
	/// </summary>
	class ContextMenus
	{
		/// <summary>
		/// Is the About box displayed?
		/// </summary>
		bool isAboutLoaded = false;

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns>ContextMenuStrip</returns>
		public ContextMenuStrip Create()
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;

		// Exit.
			item = new ToolStripMenuItem();
			item.Text = "Exit";
			item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.Exit;
			menu.Items.Add(item);

			return menu;
		}

		


		/// <summary>
		/// Processes a menu item.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}