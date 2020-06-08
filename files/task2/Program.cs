using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = @$"Folder_{0}";
            for (int i = 0; i < 90; i++)
            {
                DirectoryInfo folder = new DirectoryInfo(temp);
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
                temp += @$"/Folder_{i+1}";
            }
            Console.WriteLine("Press any key to delete directories");
            Console.ReadKey();
            Directory.Delete(@$"Folder_{0}",true);
            Console.WriteLine("Folders deleted successfully");
        }
    }
}
