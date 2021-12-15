using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Half_pipe_app
{
    public partial class Buyers_List : Form
    {
        public Buyers_List()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database.Покупатели". При необходимости она может быть перемещена или удалена.
            this.покупателиTableAdapter.Fill(this.database.Покупатели);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Выводим диалог для подтвержения удаления
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            
            if (dr == DialogResult.Cancel)
                e.Cancel = true;

            покупателиTableAdapter.Update(database); // Обновляет базу, чтоб данные сохранились
        }

        // Кнопка добавления
        private void Add_Click(object sender, EventArgs e)
        {
            Buyers.Buyers_Add af = new Buyers.Buyers_Add();

            af.Owner = this;
            af.Show();
        }

        // Кнопка удаления
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); // Получает текущую ячейку, а по ней индекс строки
                покупателиTableAdapter.Update(database); // Обновляет базу, чтоб данные сохранились
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(FindBox.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void покупателиBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
