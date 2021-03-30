namespace SC2KRepainter
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Linq;
    using System.Runtime.InteropServices;

    class SC2KRepainter
    {
        static void Main(string[] args)
        {
            Console.Write("SC2K Repainter\n\n");

            while (true)
            {
                Console.Write("Waiting for SC2K... ");

                Process process = null;

                while (process == null)
                {
                    Thread.Sleep(500);

                    process = Process.GetProcesses().SingleOrDefault(p => p.MainWindowTitle.StartsWith("SimCity 2000"));
                }

                Console.WriteLine("found\nRepainting...");

                IntPtr handle = process.MainWindowHandle;

                while (true)
                {
                    Thread.Sleep(10);

                    // Invalidate = 0x1, AllChildren = 0x80, http://www.pinvoke.net/default.aspx/Enums/RedrawWindowFlags.html
                    if (!RedrawWindow(handle, IntPtr.Zero, IntPtr.Zero, 0x01 | 0x80))
                    {
                        Console.WriteLine("Error: SC2K disconnected.");
                        break;
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
    }
}
