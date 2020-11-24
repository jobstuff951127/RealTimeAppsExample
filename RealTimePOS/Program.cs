using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTimePOS
{
    static class Program
    {
        /// <summary>
        /// This brief application was made to test one to one communication
        
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
