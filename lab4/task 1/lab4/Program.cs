using System;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace lab4
{
    class Program
    {
        static ushort InputChecker(int max)
        {
            string n;
            for (; ; )
            {
                n = Console.ReadLine();
                bool check = UInt16.TryParse(n, out ushort ni);
                if (check && (ni > 0) && (ni <= max)) return ni;
                Console.WriteLine("\nНекорректный ввод, попробуйте снова");
            }
        }
        static string[] AddFile(int amount, string[] file) 
        {
            string[] newfile = new string[amount];
            for (int i = 0; i < amount - 1; i++)
            {
                newfile[i] = file[i];
            }
            return newfile;
        }
        [DllImport("winmm.dll")]
        static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        static extern bool mciGetErrorString(uint err, StringBuilder errText, int len);
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);
        static void Open(string sFileName)
        {
            string Pcommand = string.Format("open \"{0}\" Type waveaudio Alias track", sFileName);
            Console.WriteLine(Pcommand);
            int err = mciSendString(Pcommand, null, 0, IntPtr.Zero);
            string str;
            if (err != 0)
            {
                str = errStr((uint)err);
                MessageBox(IntPtr.Zero, str, "My Message", 0);
                Console.ReadKey();
            }
        }
        static void Play()
        {
            mciSendString("play track", null, 0, IntPtr.Zero);
        }
        static void Stop()
        {
            mciSendString("stop track", null, 0, IntPtr.Zero);
            mciSendString("close track", null, 0, IntPtr.Zero);
        }
        public static string errStr(uint errCode)
        {
            StringBuilder sb = new StringBuilder(256);
            mciGetErrorString(errCode, sb, 255);
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"E:\Music");
            int i = 0;
            string[] files = new string[1];
            foreach (FileInfo file in dir.GetFiles())
            {
                files = AddFile(i + 1, files);
                files[i] = Path.GetFileNameWithoutExtension(file.FullName);
                Console.WriteLine($"{i + 1}. {files[i]}");
                i++;
            }
            int amount = i;
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("\nВведите номер трека");
                ushort pos = InputChecker(amount);
                Open($@"E:\Music\{files[pos - 1]}.wav");
                Play();
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Нажмите Escape для выхода из программы или Space для выбора нового трека");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Stop();
                        Console.Clear();
                        for (i = 0; i < amount; i++) Console.WriteLine($"{i + 1}. {files[i]}");
                        break;
                    }
                    else if (key.Key == ConsoleKey.Escape) break;
                    Console.Clear();
                }
            } while (key.Key != ConsoleKey.Escape);
            
        }
    }
}
