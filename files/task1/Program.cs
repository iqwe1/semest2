using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 90; i++)
            {
                DirectoryInfo folder = new DirectoryInfo(@$"Folder_{i}");
                folder.Create();
                if (folder.Exists)
                {
                    Console.WriteLine("FullName      : {0}", folder.FullName);
                    Console.WriteLine("Name          : {0}", folder.Name);
                    Console.WriteLine("Parent        : {0}", folder.Parent);
                    Console.WriteLine("CreationTime  : {0}", folder.CreationTime);
                    Console.WriteLine(new string('-', 40));
                }
                else
                {
                    Console.WriteLine("A directory with the name: {0} does not exist", folder.FullName);
                }
            }
            Console.WriteLine("Press any key to delete directories");
            Console.ReadKey();
            for (int i = 0; i <= 90; i++)
            {
                DirectoryInfo folder = new DirectoryInfo(@$"Folder_{i}");
                folder.Delete();
            }
            Console.WriteLine("Folders deleted successfully");
        }
    }
}
