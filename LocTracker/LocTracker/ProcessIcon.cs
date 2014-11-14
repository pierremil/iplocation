using LocTracker.Domain.Model;
using LocTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayApp;

namespace LocTracker
{
    class ProcessIcon : IDisposable
    {

        public bool ExitClicked{ get; set; }
        private Thread mainThread { get; set; }

        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
        }

        

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            ExitClicked = false;
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.LocTracker;
            ni.Text = "Location Tracker";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = new ContextMenus().Create();

            var threadStart = new ThreadStart(DisplayNotifications);
            
            mainThread = new Thread(threadStart);
            mainThread.IsBackground = true;
            mainThread.Start();           
        }

        private void DisplayNotifications()
        {
            string location_ini = string.Empty;
            while (true)
            {
                IpLocation location = new Domain.Service.IpLocationService().GetIpLocation().Result;
                if (location.IP != string.Empty)
                {
                    if (location.IP != location_ini)
                    {
                        DisplayNewIPDetected(location);
                        location_ini = location.IP;
                    }
                }
                Thread.Sleep(3000);
            }
        }
    


        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            if (mainThread.IsAlive)
            {
                mainThread.Abort();
            }
            
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
                Process.Start("explorer", null);
            }
        }

        internal void DisplayNewIPDetected(Domain.Model.IpLocation location)
        {
            ni.BalloonTipText = string.Format("At IP {0} and city {1} and country {2}", location.IP, location.City, location.Country_Name);
            ni.Text = string.Format("At IP {0} and city {1} and country {2}", location.IP,location.City,location.Country_Name);
            ni.BalloonTipTitle = "New Network detected";
            ni.ShowBalloonTip(1000);
            ni.Visible = true;
        }
    }
}
