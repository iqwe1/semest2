using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Crossword
{
    public partial class Form1 : Form
    {
        public List<TextBox> listTextBox = new List<TextBox>();
        public int counter = 1;
        public List<string> answers = new List<string>();
        public List<string> questions = new List<string>();
        public string configuration;
        public void CreaterXMLFile(string field, List<string> questions, List<string> answers)
        {
            XDocument xdoc = new XDocument();
            XElement fieldSettings = new XElement("FieldSettings");
            fieldSettings.Add(new XElement("Field", new XAttribute("Configuration", field)));
            if (questions.Count == answers.Count)
                for (int i = 0; i < questions.Count; i++)
                    fieldSettings.Add(new XElement("Description", new XAttribute("Question", questions[i]), new XAttribute("Answer", answers[i])));
            xdoc.Add(fieldSettings);
            xdoc.Save("Crosswords.xml");
        }
        public void ReaderXMLFile()
        {
            XDocument document = XDocument.Load("Crosswords.xml");
            foreach (var Element in document.Element("FieldSettings").Elements("Field"))
                configuration = Element.Attribute("Configuration").Value;
            foreach (var Element in document.Element("FieldSettings").Elements("Description"))
            {
                questions.Add(Element.Attribute("Question").Value);
                answers.Add(Element.Attribute("Answer").Value);
            }
        }
        public Form1()
        {
            InitializeComponent();
            ReaderXMLFile();
            CreaterXMLFile(configuration, questions, answers);
            FormSettings(configuration, questions, answers);
            
        }
        public void FormSettings(string configuration,List<string> tips, List<string> amswer)
        {
            string[] fields = configuration.Split(',');
            string[] parameters = fields[0].Split(' ');

            panel1.Width = Convert.ToInt32(parameters[0]);
            panel1.Height = Convert.ToInt32(parameters[1]);
            this.Width = Convert.ToInt32(parameters[0]) + 40;
            this.Height = Convert.ToInt32(parameters[1]) + 120+(tips.Count*20);

            for (int i = 0; i < tips.Count; i++)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                label.ForeColor = Color.Black;
                label.Location = new Point(10, Convert.ToInt32(parameters[1]) + 20 + (i * 20));
                if (this.Width < tips[i].Length * 8)
                    this.Width = this.Width + (tips[i].Length * 8 - this.Width);
                label.Text = tips[i];
                this.Controls.Add(label);
            }
            this.button1.Location = new Point(this.Width/3, this.Height - 90);

            for (int i = 1; i < fields.Length; i++)
            {
                int j = 0;
                parameters = fields[i].Split(' ');
                if (parameters[0] == "") j++;
                FieldCreator(Convert.ToInt32(parameters[j]), Convert.ToInt32(parameters[j + 1]), Convert.ToInt32(parameters[j + 2]), Convert.ToChar(parameters[j + 3]));
            }
        }
        public void FieldCreator(int x,int y,int l,char o)
        {
            x = x * 35;
            y = y * 35;
            x += 10;y += 10;
            for (int i = 0; i < l; i++)
            {
                TextBox textBox = new TextBox();
                if (i == 0)
                {
                    textBox.Text = counter.ToString();
                    counter++;
                }
                textBox.Font = new Font("Arial Black", 12F, FontStyle.Bold);
                textBox.Location = new Point(x, y);
                textBox.Margin = new Padding(2, 3, 2, 3);
                textBox.MaxLength = 1;
                textBox.RightToLeft = RightToLeft.Yes;
                textBox.Size = new Size(30, 30);
                textBox.TabIndex = 0;
                textBox.Name += (counter - 2) + "," + i;
                foreach (var item in listTextBox)
                {
                    if (item.Location.X == textBox.Location.X && item.Location.Y == textBox.Location.Y)
                    {
                        textBox.AccessibleName = item.Name;
                    }
                }
                textBox.TextAlign = HorizontalAlignment.Center;
                this.panel1.Controls.Add(textBox);
                if (o == 'H'|| o == 'h')
                    x += 35;
                else if (o == 'V'|| o =='v')
                    y += 35;
                listTextBox.Add(textBox);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listTextBox.Clear();
            for (int i = 1; i < panel1.Controls.Count; i++)
            {
                TextBox textBox = panel1.Controls[i] as TextBox;
                listTextBox.Add(textBox);
                
            }
            for (int i = 0; i < listTextBox.Count; i++)
            {
                if (listTextBox[i].AccessibleName != null)
                {
                    string text="";
                    for (int j = 0; j < listTextBox.Count; j++)
                    {
                        if (listTextBox[j].Name == listTextBox[i].AccessibleName)
                        {
                            text = listTextBox[j].Text;
                        }
                    }
                    listTextBox[i].Text = text;
                }
            }

            int mistakes = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                for (int j = 0; j < answers[i].Length; j++)
                {
                    foreach (var item in listTextBox)
                    {
                        string[] par=item.Name.Split(',');
                        if (par[0] == i.ToString() && par[1] == j.ToString())
                        {
                            if (item.Text.ToString() != answers[i][j].ToString())
                            {
                                mistakes++;
                            }
                        }
                    }
                }
            }
            if (mistakes == 0)
            {
                MessageBox.Show("Все вірно без жоднох перевірки");
            }
            else
            { 
                MessageBox.Show("Ви зробили "+ mistakes.ToString()+" помилок");
            }
        }
    }
}
