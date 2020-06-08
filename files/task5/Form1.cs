using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static void GetFiles(string path,string nameFile)
        {
            bool fileFound = false;
            nameFile += (nameFile.IndexOf(".") == -1? ".txt":"");
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
            {
                if (f.Name == nameFile)
                {
                    fileFound = true;
                    MessageBox.Show($"Файл знайдений\nШлях до файлу\n{f.FullName}");
                    FileStream fileStream = File.OpenRead(f.FullName);
                    // преобразуем строку в байты
                    byte[] array = new byte[fileStream.Length];
                    // считываем данные
                    fileStream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(array);
                    MessageBox.Show($"\nТекст з файлу:\n {textFromFile}");
                    break;
                }
            }
            if (fileFound == false)
            {
                MessageBox.Show("Файл не знайденно");
            }
            //DirectoryInfo[] dirArrey = dir.GetDirectories();
            //for (int i = 0; i < dirArrey.Length; i++)
            //{
            //    try
            //    {
            //        string path1 = path + dirArrey[i].Name+@"\";
            //        GetFiles(path1, nameFile);
            //    }
            //    catch
            //    {
            //        break;
            //    }
            //}
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (nameFileTextBox.Text != "" || pathTextBox.Text != "")
            {
                GetFiles(pathTextBox.Text, nameFileTextBox.Text);
            }
            else
            {
                MessageBox.Show("Введіть данні");
            }
        }
    }
}
