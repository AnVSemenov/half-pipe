using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Half_pipe_app.Buyers
{
    public partial class Buyers_Add : Form
    {
        public Buyers_Add()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Buyers_List mainForm = this.Owner as Buyers_List;

            DataRow nRow = mainForm.database.Tables["Покупатели"].NewRow();

            nRow["ФИО"] = textBox1.Text;
            nRow["Телефон"] = textBox2.Text;

            mainForm.database.Tables["Покупатели"].Rows.Add(nRow);
            mainForm.покупателиTableAdapter.Update(mainForm.database);
            mainForm.database.Tables["Покупатели"].AcceptChanges();
            mainForm.dataGridView1.Refresh();

            Close();
        }
    }
}
