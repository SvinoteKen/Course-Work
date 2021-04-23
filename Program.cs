using Serilog;
using System;
using System.Windows.Forms;

namespace School
{
    static class Status
    {
        public static bool Value { get; set; }
        public static bool Enter { get; set; }
        public static int ID { get; set; }
        public static bool Update { get; set; }
        public static string User { get; set; }
        public static bool Journal { get; set; }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("logs.log", rollingInterval: RollingInterval.Month, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Authorization f1 = new Authorization();
            if (f1.ShowDialog()==DialogResult.OK&&Status.Enter==true)
            {
                Application.Run(new DataBaseForm());
            }
            Log.CloseAndFlush();
        }
        
    }
}
