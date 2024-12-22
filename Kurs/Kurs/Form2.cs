using System;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form2 : Form
    {
        private readonly Form1 _parentForm;

        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox2.Text, out decimal pricePerMonth) &&
                int.TryParse(textBox3.Text, out int numberOfMonths) && !string.IsNullOrEmpty(textBox1.Text))
            {
                string campaignName = textBox1.Text;
                string infoCamp = textBox4.Text;
                string startRec = textBox5.Text;
                string endRec = textBox6.Text;
                _parentForm.AddExpense(campaignName, infoCamp, pricePerMonth, numberOfMonths, startRec, endRec); 

                MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                this.Close();
                _parentForm.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения и название кампании.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}