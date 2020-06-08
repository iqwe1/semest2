using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        TextBox t = new TextBox();
        Random rand = new Random();
        List<int> defectList = new List<int>();
        List<Button> butonsList = new List<Button>();
        int counter = 1;
        public Form1()
        {
            InitializeComponent();
            int x = 150;
            int y = 50;
            t.BackColor = Color.LightBlue;
            t.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            t.ForeColor = Color.White;
            t.Location = new Point(x , y+200);
            t.Size = new Size(190, 30);
            t.TextAlign = HorizontalAlignment.Center;
            t.ReadOnly = true;
            this.tabPage2.Controls.Add(t);
            //Вертикаль
            for (int i = 0; i < 4; i++)
            {
                //Горизонталь
                for (int j = 0; j < 4; j++)
                {
                    Button b = new Button();
                    b.Visible = true;
                    b.Size = new Size(40, 30);
                    b.Location = new Point(x + j * 50, y + 40 * i);
                    b.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
                    this.tabPage2.Controls.Add(b);
                    b.MouseClick += Button_MouseClick;
                    butonsList.Add(b);
                    int r = rand.Next(counter, 17);
                    while (defectList.IndexOf(r) != -1)
                        r = rand.Next(counter, 17);
                    defectList.Add(r);
                    b.Text = r.ToString();
                }
            }
            defectList.Clear();

        }
        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = false;
            int numberButton;
            numberButton = Convert.ToInt32((sender as Button).Text);
            if (numberButton == counter)
            {
                (sender as Button).Visible = false;
                counter++;
                for (int i = 0; i < butonsList.Count; i++)
                {
                    if (butonsList[i].Visible == true)
                    {
                        b = true;
                        int r = rand.Next(counter, 17);
                        while (defectList.IndexOf(r) != -1)
                            r = rand.Next(counter, 17);
                        defectList.Add(r);
                        butonsList[i].Text = r.ToString();
                    }
                }
                defectList.Clear();
            }
            else
            {
                b = true;
                counter = 1;
                for (int i = 0; i < butonsList.Count; i++)
                {
                    butonsList[i].Visible = true;
                    int r = rand.Next(counter, 17);
                    while (defectList.IndexOf(r) != -1)
                        r = rand.Next(counter, 17);
                    defectList.Add(r);
                    butonsList[i].Text = r.ToString();
                }
                defectList.Clear();
            }
            if (b == false)
                t.Text = "Good Job!!!";
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.RemoveAt(comboBox1.Items.Count-1);
            textBox1.Text = "";
        }
    }
}
