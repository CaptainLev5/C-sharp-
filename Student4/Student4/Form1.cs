using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Student4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\Proga\\student.txt"))
            {
                Form3 f = new Form3();
                f.Show();
            }
            else
            {
                MessageBox.Show("Файла нет");
                return;
            }
           
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}