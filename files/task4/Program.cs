using System;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string temp = @$"{i}";
            try
            {
                while (true)
                {
                    DirectoryInfo folder = new DirectoryInfo(temp);
                    folder.Create();
                    if (folder.Exists)
                    {
                        Console.WriteLine("Name : {0}", folder.Name);
                        Console.WriteLine(new string('-', 40));
                        folder.Delete();
                    }
                    else
                    {
                        Console.WriteLine("A directory with the name: {0} does not exist", folder.FullName);
                    }
                    temp += @$"{i+1}";
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExeption: " + e.Message);
            }
            Console.WriteLine($"\n\nThe largest name for the folder has - {i} characters");
        }
    }
}
