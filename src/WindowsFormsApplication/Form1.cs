using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        ToolStripLabel infoLabel;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Статус расчёта";
            statusStrip1.Items.Add(infoLabel);
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
        }
        void timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    if((myStream=openFileDialog1.OpenFile())!=null)
                    {
                        using (myStream)
                        {
                            webBrowser1.Navigate(openFileDialog1.FileName);
                            this.WindowState = FormWindowState.Maximized;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка: Нельзя считать файл с диска. Ошибка:" + ex.Message);
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор работы: Саутин Олег Дмитриевич; Вариант 3.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X = Convert.ToInt32(textBox1.Text);
            int Y = Convert.ToInt32(textBox2.Text);
            int sum = System.Math.Abs(X) + System.Math.Abs(Y);
            double round = System.Math.Pow(X, 2) + System.Math.Pow(Y, 2);
            if (sum < 2 && X > 0 && Y<0 | sum < 2 && X < 0 && Y > 0| sum > 2 && X > 0 && Y > 0 | sum > 2 && X < 0 && Y < 0)
            {
                infoLabel.Text = "Точка попадает в область";
                MessageBox.Show("Точка попадает в область");
            }
            else if (sum < 2 && X > 0 && Y > 0 | sum < 2 && X < 0 && Y < 0 | sum > 2 && X < 0 && Y > 0 | sum > 2 && X < 0 && Y < 0)
            {
                infoLabel.Text = "Точка не попадает в область";
                MessageBox.Show("Точка не попадает в область");
            }
            else
            {
                infoLabel.Text = "Точка на границе";
                MessageBox.Show("Точка на границе");
            }
        }
    }
}