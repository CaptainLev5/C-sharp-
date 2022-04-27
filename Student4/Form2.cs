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
    public partial class Form2 : Form
    {
        string ln;
        string fn;
        static string gr;
        double ex;
        double cw;

        List<Student> student_list = new List<Student>();
        List<Student_Pie> student_pie_list = new List<Student_Pie>();


        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;

            string[] group = { "ПИэ21_21", "ПИэ20_20", "ПИэ19_19", "ПИэ18_18" };


            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DataSource = group;
            comboBox1.SelectedIndex = 0;

            exam.KeyPress += exam_KeyPress;
            coursework.KeyPress += exam_KeyPress;
            //exam.TextChanged += mark_TextChanged;
            //coursework.TextChanged += mark_TextChanged;
        }
        static void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            gr = comboBox.SelectedItem.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.InitialDirectory = "D:\\Proga";
            openPicture.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";


            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void exam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ввод в texBox только цифр и ','
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',')
            {
                e.Handled = true;
            }
        }

        private bool checkField()
        {
            if (lastname.Text != String.Empty)
            {
                ln = lastname.Text;
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия");
                lastname.Focus();
                return false;
            }
            if (firstname.Text != String.Empty)
            {
                fn = firstname.Text;
            }
            else
            {
                firstname.Focus();
                MessageBox.Show("Заполните поле Имя");
                return false;
            }
            if (exam.Text != String.Empty)
            {
                //ex= exam.Text;
                ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
            }
            else
            {
                exam.Focus();
                MessageBox.Show("Заполните поле Экзамен");
                return false;
            }
            if (coursework.Text != String.Empty)
            {
                //s = s + coursework.Text;
                cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
            }
            else
            {
                coursework.Focus();
                MessageBox.Show("Заполните поле Курсовая работа");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // foreach (Control ctrl in this.Controls)
            // {
            // if (ctrl.GetType() == typeof(TextBox))
            // if ((String)ctrl.Text == "") MessageBox.Show("Всё пропало!");
            // }
            if (lastname.Text != String.Empty)
            {
                ln = lastname.Text;
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия");
                lastname.Focus();
                return;
            }
            if (firstname.Text != String.Empty)
            {
                fn = firstname.Text;
            }
            else
            {
                firstname.Focus();
                MessageBox.Show("Заполните поле Имя");
                return;
            }
            if (exam.Text != String.Empty)
            {
                ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
            }
            else
            {
                exam.Focus();
                MessageBox.Show("Заполните поле Экзамен");
                return;
            }
            if (coursework.Text != String.Empty)
            {
                cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
            }
            else
            {
                coursework.Focus();
                MessageBox.Show("Заполните поле Курсовая работа");
                return;
            }


            Student s = new Student(ln, fn, gr, ex, cw);

            MessageBox.Show(s.Info());

            // true – в файл можно дописывать
            StreamWriter streamwriter = new StreamWriter(@"d:\Proga\student.txt", true,
            System.Text.Encoding.GetEncoding("utf-8"));
            streamwriter.WriteLine(s.Info());
            streamwriter.Close();
            // запись содержимого pictureBox1
            pictureBox1.Image.Save(@"d:\Proga\" + lastname.Text + ".jpg");


            //    ------------------------------------------


            string path = "D:\\Proga\\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                MessageBox.Show("Create dir D:\\Proga\\");
            }
            String fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";

            saveFileDialog.Title = "Сохранить успеваемость";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            // saveFileDialog.FileName = comboBox1.SelectedItem.ToString();
            saveFileDialog.FileName = "D:\\Proga\\student27.04.txt";

            string path_images = "D:\\Proga\\images27.04";
            DirectoryInfo dir_images = new DirectoryInfo(path_images);
            if (!dirInfo.Exists)
            {
                dir_images.Create();
                MessageBox.Show("Create dir D:\\Proga\\");
            }
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;// Сохранить имя файла
                //StreamWriter streamwriter = new StreamWriter(fileName, true,
               //System.Text.Encoding.GetEncoding("utf-8"));
                // streamwriter.WriteLine(s.Info());
                //streamwriter.Close();
                pictureBox1.Image.Save("D:\\Proga\\images27.04" + lastname.Text +
               ".jpg");

                // ------------------------------------------
            }
        }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double sred_ball = 0;
            if (exam.Text != String.Empty)
            {

                ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
            }
            else
            {
                exam.Focus();
                MessageBox.Show("Заполните поле Экзамен");
                return;
            }
            if (coursework.Text != String.Empty)
            {

                cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
            }
            else
            {
                coursework.Focus();
                MessageBox.Show("Заполните поле Курсовая работа");
                return;
            }

            sred_ball = (ex + cw) / 2;
            averageball.Text = sred_ball.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkField())
            {
                Student s;
                s = new Student(ln, fn, gr, ex, cw);
                student_list.Add(s);
                student_list.Sort();
                string message = "";
                foreach (var x in student_list) message += x.Info() + "\n";
                MessageBox.Show(message);
                string path = "D:\\Proga";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    MessageBox.Show("Create dir D:\\Proga\\");
                }
                StreamWriter file = new StreamWriter("D:\\Proga\\student.txt");
                foreach (var x in student_list)
                    file.WriteLine(x.Info());
                file.Close();
            }
        }

       /* private void button4_Click(object sender, EventArgs e) //тестовая
        {

        }
       */

        private void button5_Click(object sender, EventArgs e) // очистка
        {
            lastname.Text = "";
            firstname.Text = "";
            exam.Text = "";
            coursework.Text = "";
        }
        
    }

    /*private void mark_TextChanged(object sender, EventArgs e)
    {
        checkBox1.Checked = false;
        averageball.Text = "";
    }
   */

   


}
