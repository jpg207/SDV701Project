using System;
using System.Windows.Forms;

namespace AdminApp
{
    public static class Program
    {
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
