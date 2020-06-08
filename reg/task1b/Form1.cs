using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Task_1_b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                if (ReadSettings() == false)
                {
                    MessageBox.Show("У файлі немає інформації...");
                }
                else
                {
                    MessageBox.Show("Інформація успішно завантажена з файлу ...");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Виникла проблема при завантаженні даних з файлу :\n" + e.Message);
            }
        }

        private bool ReadSettings()
        {
            StreamReader reader = File.OpenText("Settings.txt");
            if (reader == null) return false;
            string input;

            string[] values = new string[] {
                Location.X.ToString(),
                Location.Y.ToString(),
                Height.ToString(),
                Width.ToString(),
                checkBox1.Checked.ToString(),
                checkBox2.Checked.ToString(),
                textBox1.Text.ToString()
            };
            int x = Convert.ToInt32(reader.ReadLine().Split(':')[1]);
            int y = Convert.ToInt32(reader.ReadLine().Split(':')[1]);
            this.Location = new Point(x,y);
            this.Height = Convert.ToInt32(reader.ReadLine().Split(':')[1]);
            this.Width = Convert.ToInt32(reader.ReadLine().Split(':')[1]);
            this.checkBox1.Checked = Convert.ToBoolean(reader.ReadLine().Split(':')[1]);
            this.checkBox2.Checked = Convert.ToBoolean(reader.ReadLine().Split(':')[1]);
            this.textBox1.Text = reader.ReadLine().Split(':')[1];
            reader.Close();
            return true;
        }

        void SaveSettings()
        {
            FileInfo file = new FileInfo(@"Settings.txt");
            StreamWriter writer = file.CreateText();
            writer.WriteLine("this.LocationX:" + this.Location.X);
            writer.WriteLine("this.LocationY:" + this.Location.Y);
            writer.WriteLine("Window.Height:"+this.Height);
            writer.WriteLine("Window.Width:" + this.Width);
            writer.WriteLine("checkBox1.Checked:" + this.checkBox1.Checked);
            writer.WriteLine("checkBox2.Checked:" + this.checkBox1.Checked);
            writer.WriteLine("textBox1.Text:" + this.textBox1.Text);
            writer.Close();
        }
    }
}
