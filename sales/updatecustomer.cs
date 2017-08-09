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
    public partial class updatecustomer : Form
    {
        public updatecustomer()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string a = textBox1.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Customer> ils = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.InsensitiveLike("CustomerName", a, MatchMode.Anywhere)).List<Customer>();
            foreach (Customer pi in ils)
            {
                string[] ro4 = new string[] { pi.CustomerId.ToString(), pi.CustomerName.ToString(), pi.CustomerPhoneNumber.ToString(), pi.CustomerBalance.ToString(), pi.CustomerAddress.ToString() };
                dataGridView1.Rows.Add(ro4);
            }
//            dataGridView1.DataSource = ils;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {   
            Customer ee = new Customer();

            ee.CustomerName = textBox3.Text;
            ee.CustomerPhoneNumber = textBox4.Text;
            ee.CustomerId = Int32.Parse(label7.Text);
            ee.CustomerAddress = textBox6.Text;
            ee.CustomerBalance = Convert.ToInt32(textBox5.Text);

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
                  //  throw ex;
                }
            }
            
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            label7.Text = ".......";
             }        
            else MessageBox.Show("SOMETTHING IS MISSING");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            label7.Text = row.Cells[0].Value.ToString();
           textBox3.Text=row.Cells[1].Value.ToString();
           textBox4.Text = row.Cells[2].Value.ToString();
           textBox6.Text = row.Cells[4].Value.ToString();
           textBox5.Text = row.Cells[6].Value.ToString();
        }
    }
}
