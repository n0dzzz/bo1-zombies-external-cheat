using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace zomHack
{
    internal class main
    {
        [DllImport("kernel32.dll")]

        static extern bool WriteProcessMemory(IntPtr proc, int Base, byte[] buffer, int size, ref int written);

        static IntPtr proc = Process.GetProcessesByName("blackops")[0].Handle;
        static int written = 0;

        static string consoleUserInput = "";
        static Int32 pointAmount = 0;
        static Int32 weaponHackId = 2;
        static bool isGodMode = false;

        static void consoleHome()
        {
            Console.WriteLine("zomHack by n0d");
            Console.WriteLine("black ops 1 zombies external trainer");
            Console.WriteLine("");
            Console.WriteLine("[1] Set Points");
            Console.WriteLine("[2] Weapon Hack");
            Console.WriteLine("[3] Ammo Hack");

            consoleUserInput = Console.ReadLine();

            if (consoleUserInput == "1")
            {
                Console.WriteLine("enter point amount");
                pointAmount = Int32.Parse(Console.ReadLine());
                pointHack();

                Console.Clear();
                consoleHome();
            }

            if (consoleUserInput == "2")
            {
                Console.WriteLine("enter weapon id");
                weaponHackId = Int32.Parse(Console.ReadLine());
                weaponHack();

                Console.Clear();
                consoleHome();
            }

            if (consoleUserInput == "3")
            {
                ammoHack();

                Console.Clear();
                consoleHome();
            }
        }

        static void pointHack()
        {
            byte[] pointAmountBuf = BitConverter.GetBytes(pointAmount);
            WriteProcessMemory(proc, 0x01C0A6C8, pointAmountBuf, pointAmountBuf.Length, ref written);
        }

        static void weaponHack()
        {
            byte[] weaponHackBuf = BitConverter.GetBytes(weaponHackId);    
            WriteProcessMemory(proc, 0x01C08D34, weaponHackBuf, weaponHackBuf.Length, ref written);
        }

        static void ammoHack()
        {
            byte[] secondaryAmmoBuf = BitConverter.GetBytes(9999999);
            WriteProcessMemory(proc, 0x01C08F00, secondaryAmmoBuf, secondaryAmmoBuf.Length, ref written);

            byte[] primaryAmmoBuf = BitConverter.GetBytes(9999999);
            WriteProcessMemory(proc, 0x01C08F10, primaryAmmoBuf, primaryAmmoBuf.Length, ref written);
        }

        static void Main(string[] args)
        { 
            Console.ForegroundColor = ConsoleColor.Magenta;
            consoleHome();
        }
    }
}
