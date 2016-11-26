﻿using System;
using System.Windows.Forms;

namespace TrayIconBluetoothController
{
    public partial class Form1 : Form
    {
        private bool allowshowdisplay = false;


        public Form1() {
            InitializeComponent();
            //allowshowdisplay = true;
            //Console.WriteLine(this.WindowState);
            //Form1_Move(this, null);

            //this.notifyIcon1.Icon = new ((System.Drawing.Icon)(resources.GetObject("redBTicon.ico")));
            //this.notifyIcon1.Icon = new Icon("Resources/redBTicon.ico"); //((System.Drawing.Icon)(("redBTicon.ico")));
            //System.ComponentModel.ComponentResourceManager resources

            //BluetoothConnector btConnector = new BluetoothConnector(this);
            //WiFiDirectConnector wifiConnector = new WiFiDirectConnector(this);
            WlanConnector wlanConnector = new WlanConnector(this);
        }

        // To hide the form in tray on startup
        protected override void SetVisibleCore(bool value) {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void Form1_Move(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            allowshowdisplay = true;
            this.Show();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            allowshowdisplay = true;
            this.BringToFront();
            this.Show();
        }

        public void NotifyLostConnection() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.red")));
        }

        public void NotifyEstablishedConnection() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.green")));
        }
    }
}
