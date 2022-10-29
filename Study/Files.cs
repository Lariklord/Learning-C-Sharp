using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Study
{
    internal class Files
    {
        static ulong a = 0;
        public static void Drivs()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine();
            foreach (var item in drives)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Toyal size: {item.TotalSize/Math.Pow(10,9)} гб");
                Console.WriteLine($"Total free space: {item.TotalFreeSpace / Math.Pow(10, 9)} гб");
                Console.WriteLine($"Free space: {item.AvailableFreeSpace/Math.Pow(10,9)} гб");
                Console.WriteLine($"Format: {item.DriveFormat}");
                Console.WriteLine($"Type: {item.DriveType}");
                Console.WriteLine($"Label: {item.VolumeLabel}");
                Console.WriteLine();
            }
        }
        public static void Catalogs()
        {/*
            string dirName = "C:\\";
            if(Directory.Exists(dirName))
            {
                Console.WriteLine("Catalogs:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (var item in dirs)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.WriteLine("Files:");
                string[] fils = Directory.GetFiles(dirName);
                foreach (var item in fils)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
            var dir = new DirectoryInfo(dirName);
            if(dir.Exists)
            {
                Console.WriteLine("Catalogs:");
                DirectoryInfo[] dirInfo = dir.GetDirectories();
                foreach (var item in dirInfo)
                {
                    Console.WriteLine(item.FullName);
                }
                Console.WriteLine();
                Console.WriteLine("Files:");
                FileInfo[] filInfo = dir.GetFiles();
                foreach (var item in filInfo)
                {
                    Console.WriteLine(item.FullName);
                }
            }
            Console.WriteLine();
            string[] files = Directory.GetFiles(dirName, "*.exe");

            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Directory.CreateDirectory($"{path}/{subpath}");

            string dirNameC = "C:\\Program files";
            DirectoryInfo directory = new DirectoryInfo(dirNameC);
            Console.WriteLine($"Name: {directory.Name}");
            Console.WriteLine($"Full name: {directory.FullName}");
            Console.WriteLine($"Time of creating: {directory.CreationTime}");
            Console.WriteLine($"Root: {directory.Root}");
            Console.WriteLine();
            DirectoryInfo some = new DirectoryInfo(path);
            if(some.Exists)
            {
                some.Delete(true);
                Console.WriteLine("удален");
            }
            else
                Console.WriteLine("не сущ");
            */
            Get(new DirectoryInfo("C:\\"));
            Console.WriteLine();
            Console.WriteLine(a);
        }

        public static void Get(DirectoryInfo info)
        {
            if(!info.Exists)
            {
                return;
            }

            try
            {
                if (info.GetDirectories().Length == 0)
                    return;
            }
            catch (Exception)
            {
                return ;
            }
           
            foreach (var item in info.GetDirectories())
            {
                Console.WriteLine($"{item.Name}");
                if (item.Name.Contains("Recycle.Bin"))
                    continue;
                else
                {
                    a++;
                    Get(item);
                }
            }
        }
    }
}
