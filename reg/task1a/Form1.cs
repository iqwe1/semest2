using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Task_1_a
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
                    MessageBox.Show("У файлі XML немає інформації...");
                }
                else
                {
                    MessageBox.Show("Інформація успішно завантажена з файлу XML...");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Виникла проблема при завантаженні даних з файлу XML:\n" + e.Message);
            }
        }

        private bool ReadSettings()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count < 1)
            return false;

            //1. Розташування на екрані.
            int X = Convert.ToInt32(allAppSettings["X"]);
            int Y = Convert.ToInt32(allAppSettings["Y"]);
            this.Location = new Point(X, Y);

            //2. Розмір вікна.
            this.Height = Convert.ToInt32(allAppSettings["Window.Height"]);
            this.Width = Convert.ToInt32(allAppSettings["Window.Width"]);

            //3. СheckBox.
            checkBox1.Checked = Convert.ToBoolean(allAppSettings["checkBox1.Checked"]);
            checkBox2.Checked = Convert.ToBoolean(allAppSettings["checkBox2.Checked"]);

            //4. TextBox.
            textBox1.Text = allAppSettings["textBox1.Text"];
            return true;
        }
        void SaveSettings()
        {
            XmlDocument doc = loadConfigDocument();
            XmlNode node = doc.SelectSingleNode("//appSettings");

            string[] keys = new string[] {
                "X",
                "Y",
                "Window.Height",
                "Window.Width",
                "checkBox1.Checked",
                "checkBox2.Checked",
                "textBox1.Text"
            };
            string[] values = new string[] {
                Location.X.ToString(),
                Location.Y.ToString(),
                Height.ToString(),
                Width.ToString(),
                checkBox1.Checked.ToString(),
                checkBox2.Checked.ToString(),
                textBox1.Text.ToString()
            };

            // Цикл модификации файла конфигурации.
            for (int i = 0; i < keys.Length; i++)
            {
                // Обращаемся к конкретной строке по ключу.
                XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                // Если строка с таким ключем существует - записываем значение.
                if (element != null) { element.SetAttribute("value", values[i]); }
                else
                {
                    // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", keys[i]);
                    element.SetAttribute("value", values[i]);
                    node.AppendChild(element);
                }
            }
            // Сохраняем результат модификации.
            doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
        }
        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
    }
}
