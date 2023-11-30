using SistemaAcademicoPUC.Recursos;

namespace SistemaAcademicoPUC
{
    internal static class Program
    {
        public static AppData appData;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            appData = new AppData();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaLogin());
        }
    }
}