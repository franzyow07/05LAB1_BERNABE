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

namespace _05LAB1_BERNABE
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                string fileName = textBox1.Text.Trim() + ".txt";
                string fullPath = Path.Combine(docPath, fileName);

                string studentNo = textBox1.Text.Trim();
                string fullName = $"{textBox3.Text.Trim()}, {textBox2.Text.Trim()}, {textBox4.Text.Trim()}";
                string program = comboBox2.Text;
                string gender = comboBox1.Text;
                string age = textBox6.Text.Trim();
                string birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string contactNo = textBox5.Text.Trim();

                string[] lines =
                {
                    $"Student No.: {studentNo}",
                    $"Full Name: {fullName}",
                    $"Program: {program}",
                    $"Gender: {gender}",
                    $"Age: {age}",
                    $"Birthday: {birthday}",
                    $"Contact No.: {contactNo}"
                };

                using (StreamWriter outputFile = new StreamWriter(fullPath))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }

                MessageBox.Show($"Registration saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
