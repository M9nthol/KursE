using System;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form3 : Form
    {
        private readonly Form1 _parentForm;
        public Form3(Form1 parent)
        {
            InitializeComponent();
            _parentForm = parent;
            InitializeDataGridView();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("CampaignName", "Название кампании");
            dataGridView1.Columns.Add("InfoCamp", "Информация о услуге");
            dataGridView1.Columns.Add("PricePerMonth", "Цена за месяц");
            dataGridView1.Columns.Add("NumberOfMonths", "Количество месяцев");
            dataGridView1.Columns.Add("TotalCost", "Общая стоимость");
            dataGridView1.Columns.Add("StartRec", "Дата начала");
            dataGridView1.Columns.Add("EndRec", "Дата окончания");

            foreach (var expense in _parentForm.Expenses)
            {
                dataGridView1.Rows.Add(expense.CampaignName, expense.InfoCamp, expense.PricePerMonth, expense.NumberOfMonths, expense.TotalCost, expense.StartRec, expense.EndRec);
            }

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Удалить";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parentForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
               
                int rowIndex = e.RowIndex;

                
                string campaignName = dataGridView1.Rows[rowIndex].Cells["CampaignName"].Value.ToString();

                string infoCamp = dataGridView1.Rows[rowIndex].Cells["InfoCamp"].Value.ToString();

                decimal pricePerMonth = decimal.Parse(dataGridView1.Rows[rowIndex].Cells["PricePerMonth"].Value.ToString());

                int numberOfMonths = int.Parse(dataGridView1.Rows[rowIndex].Cells["NumberOfMonths"].Value.ToString());

                
                Expense expenseToRemove = _parentForm.Expenses.Find(e => e.CampaignName == campaignName && e.InfoCamp == infoCamp
                                                                && e.PricePerMonth == pricePerMonth && e.NumberOfMonths == numberOfMonths);


                if (expenseToRemove != null)
                {
                   
                    _parentForm.RemoveExpense(expenseToRemove);
                
                    dataGridView1.Rows.RemoveAt(rowIndex);

                }
                else
                {
                    MessageBox.Show("Ошибка при удалении записи, попробуйте ещё раз");
                }

            }
        }
    }
}
