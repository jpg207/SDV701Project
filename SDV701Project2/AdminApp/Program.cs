﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdminApp
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsCruiser.LoadCruiserForm = new clsCruiser.LoadCruiserFormDelegate(frmCruiser.Run);
            clsBattleShip.LoadBattleShipForm = new clsBattleShip.LoadBattleShipFormDelegate(frmBattleShip.Run);
            Application.Run(frmMain.Instance);
        }
    }
}
