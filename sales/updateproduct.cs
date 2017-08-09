using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace sales
{
    public partial class updateproduct : Form
    {
        public updateproduct()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string a = textBox1.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Products> ils = NH.CreateCriteria(typeof(Products)).Add(Restrictions.InsensitiveLike("ProductName", a, MatchMode.Anywhere)).List<Products>();
            foreach (Products pi in ils)
            {
                string[] ro4 = new string[] { pi.ProductId.ToString(), pi.ProductName.ToString(), pi.ProductPrice.ToString(), pi.SalePrice.ToString() };
                dataGridView1.Rows.Add(ro4);
            } 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label6.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Products ee = new Products();

                ee.ProductName = textBox3.Text;
                ee.ProductPrice = Convert.ToInt32(textBox4.Text);
                ee.ProductId = Convert.ToInt32(label6.Text);

                ee.SalePrice = Convert.ToInt32(textBox5.Text);

                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NH.BeginTransaction())
                {

                    try
                    {

                        // ee.Login
                        NH.Update(ee);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("INCOMPLETE TRANSACTION");
                        //throw ex;
                    }
                }

                textBox5.Text = "";
                label6.Text = "......";
                textBox4.Text = "";
                textBox3.Text = "";
            }
            else MessageBox.Show("SOMETTHING IS MISSING");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            label6.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
            textBox5.Text = row.Cells[3].Value.ToString();
        }
    }
}
