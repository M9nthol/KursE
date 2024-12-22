using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        public List<Expense> Expenses { get; private set; } = new List<Expense>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateLabelSum();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(this);

            this.Hide();

            form2.Show();
        }
        // Обновление Label на основе текущей суммы
        public void UpdateLabelSum()
        {
            label1.Text = $"Общая сумма расходов: {CalculateTotalExpenses():C}";
        }
        public void AddExpense(string campaignName, string infoCamp, decimal pricePerMonth, int numberOfMonths, string startRec, string endRec)
        {
            Expenses.Add(new Expense { CampaignName = campaignName, InfoCamp = infoCamp, StartRec= startRec, EndRec = endRec, PricePerMonth = pricePerMonth, NumberOfMonths = numberOfMonths });
            UpdateLabelSum();
        }

        public void RemoveExpense(Expense expense)
        {
            Expenses.Remove(expense);
            UpdateLabelSum();
        }
        // Метод для пересчета всех расходов
        public decimal CalculateTotalExpenses()
        {
            decimal total = 0;
            foreach (var expense in Expenses)
            {
                total += expense.TotalCost;
            }
            return total;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);

            this.Hide();

            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    // Класс для представления одного расхода
    public class Expense
    {
        public string CampaignName { get; set; }
        public string InfoCamp { get; set; }
        public string StartRec { get; set; }
        public string EndRec { get; set; }
        public decimal PricePerMonth { get; set; }
        public int NumberOfMonths { get; set; }

        // Можно добавить метод для получения полной стоимости расхода
        public decimal TotalCost => PricePerMonth * NumberOfMonths;
    }
}