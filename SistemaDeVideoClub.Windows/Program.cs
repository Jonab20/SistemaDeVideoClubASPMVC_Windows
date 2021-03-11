using SistemaDeVideoClub.Windows.Mapeador;
using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DI.Inicialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Init();
            Application.Run(DI.Create<FrmMenuPrincipal>());
        }
    }
}
