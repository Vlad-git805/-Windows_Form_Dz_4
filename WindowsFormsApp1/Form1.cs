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
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Worker> workers;
        
        public Form1()
        {
            InitializeComponent();

            workers = new List<Worker>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Примінити")
            {
                bool check1 = true;
                bool check2 = true;
                bool check3 = true;
                bool check4 = true;
                bool check5 = true;
                bool check6 = true;
                Worker wk = new Worker();
                if (textBox1.Text != "")
                    wk.Surname = textBox1.Text;
                else
                    check1 = false;
                if (numericUpDown1.Value > 0 && numericUpDown1.Value < 1000000)
                    wk.Selery = numericUpDown1.Value;
                else
                    check2 = false;
                if (comboBox1.Text != "")
                    wk.Position = comboBox1.Text;
                else
                    check3 = false;
                if (comboBox2.Text != "")
                    wk.City = comboBox2.Text;
                else
                    check4 = false;
                if (comboBox3.Text != "")
                    wk.Street = comboBox3.Text;
                else
                    check5 = false;
                if (numericUpDown2.Value > 0 && numericUpDown2.Value < 10000)
                    wk.Hous = numericUpDown2.Value;
                else
                    check6 = false;
                if (check1 == true && check2 == true && check3 == true && check4 == true && check5 == true && check6 == true)
                {
                    workers.Add(wk);
                    MessageBox.Show(wk.ToString());
                    listBox1.Items.Add(wk);
                    textBox1.ResetText();
                    numericUpDown1.Value = 0;
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();
                    numericUpDown2.Value = 0;
                }
            }
            else if (button2.Text == "Змінити")
            {
                bool check1 = true;
                bool check2 = true;
                bool check3 = true;
                bool check4 = true;
                bool check5 = true;
                bool check6 = true;
                if (textBox1.Text != "")
                    workers[listBox1.SelectedIndex].Surname = textBox1.Text;
                else
                    check1 = false;
                if (numericUpDown1.Value > 0 && numericUpDown1.Value < 1000000)
                    workers[listBox1.SelectedIndex].Selery = numericUpDown1.Value;
                else
                    check2 = false;
                if (comboBox1.Text != "")
                    workers[listBox1.SelectedIndex].Position = comboBox1.Text;
                else
                    check3 = false;
                if (comboBox2.Text != "")
                    workers[listBox1.SelectedIndex].City = comboBox2.Text;
                else
                    check4 = false;
                if (comboBox3.Text != "")
                    workers[listBox1.SelectedIndex].Street = comboBox3.Text;
                else
                    check5 = false;
                if (numericUpDown2.Value > 0 && numericUpDown2.Value < 10000)
                    workers[listBox1.SelectedIndex].Hous = numericUpDown2.Value;
                else
                    check6 = false;
                if (check1 == true && check2 == true && check3 == true && check4 == true && check5 == true && check6 == true)
                {
                    textBox1.ResetText();
                    numericUpDown1.Value = 0;
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();
                    numericUpDown2.Value = 0;
                    button2.Text = "Примінити";
                    foreach (Worker item in workers)
                    {
                        listBox1.Items.Remove(item);
                    }
                    foreach (Worker item in workers)
                    {
                        listBox1.Items.Add(item.ToString());
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                workers.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = workers[listBox1.SelectedIndex].Surname;
            numericUpDown1.Value = workers[listBox1.SelectedIndex].Selery;
            comboBox1.Text = workers[listBox1.SelectedIndex].Position;
            comboBox2.Text = workers[listBox1.SelectedIndex].City;
            comboBox3.Text = workers[listBox1.SelectedIndex].Street;
            numericUpDown2.Value = workers[listBox1.SelectedIndex].Hous;

            button2.Text = "Змінити";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Worker>));
                formatter.Serialize(fs, workers);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("heroe.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Worker>));
                List<Worker> newlistWorkers = (List<Worker>)formatter.Deserialize(fs);
                workers = newlistWorkers;
            }

            foreach (var item in workers)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
