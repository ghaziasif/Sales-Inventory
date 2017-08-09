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
    public partial class supplierupdate : Form
    {
        public supplierupdate()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string a = textBox1.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.InsensitiveLike("SupplierName", a, MatchMode.Anywhere)).List<Supplier>();
            foreach (Supplier pi in ils)
            {
                string[] ro4 = new string[] { pi.SupplierId.ToString(), pi.SupplierName.ToString(), pi.SupplierPhoneNumber.ToString(), pi.SupplierBalance.ToString(), pi.SupplierAddress.ToString() };
                dataGridView1.Rows.Add(ro4);
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {                Supplier ee = new Supplier();

            ee.SupplierName = textBox3.Text;
            ee.SupplierPhoneNumber = textBox4.Text;
            ee.SupplierId = Convert.ToInt32(label7.Text);
            ee.SupplierAddress = textBox6.Text;
            ee.SupplierBalance = Convert.ToInt32(textBox5.Text);

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
            label7.Text = ".......";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
           // textBox2.Text = "";
        }        
            else MessageBox.Show("SOMETTHING IS MISSING");
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            label7.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
        }
    }
}
