using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;

namespace SDV701ProjectVS
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsBattleShip.LoadBattleShipForm = new clsBattleShip.LoadBattleShipFormDelegate(frmBattleship.Run);
            clsCruiser.LoadCruiserForm = new clsCruiser.LoadCruiserFormDelegate(frmCruiser.Run);
            Application.Run(frmMain.Instance);
        }
    }
}
