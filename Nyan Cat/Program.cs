using System;
using System.Threading;
using System.Windows.Forms;

namespace Nyan_Cat
{
    public static class Program
    {
        public static readonly Random random = new Random();

        private static void formThread()
        {
            Application.Run(new NyanForm());
        }

        private static void infoThread()
        {
            Application.Run(new NyanInfo());
        }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new Thread(infoThread).Start();
            ThreadPool.SetMaxThreads(8, 8);
            while (true)
            {
                if (random.Next(100) < 60)
                {
                    try
                    {
                        ThreadPool.QueueUserWorkItem(callback =>
                        {
                            formThread();
                        });
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}