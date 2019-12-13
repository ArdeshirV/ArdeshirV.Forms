// Copyright© 2002-2019 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.Windows.Forms;

namespace ArdeshirV.TestForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainTest());
        }
    }
}
