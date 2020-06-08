using System;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = @$"Folder_{0}";
            int i = 0;
            try
            {
                while (true)
                {
                    DirectoryInfo folder = new DirectoryInfo(temp);
                    folder.Create();
                    if (folder.Exists)
                    {
                        Console.WriteLine("Name          : {0}", folder.Name);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("A directory with the name: {0} does not exist", folder.FullName);
                    }
                    temp += @$"/Folder_{i + 1}";
                    i++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nExeption: "+ e.Message);
            }
            Console.WriteLine($"\n\nThe largest number of subfolders is: {i}");
            Console.WriteLine("Press any key to delete directories");
            Console.ReadKey();
            Directory.Delete(@$"Folder_{0}", true);
            Console.WriteLine("Folders deleted successfully");
        }
    }
}
