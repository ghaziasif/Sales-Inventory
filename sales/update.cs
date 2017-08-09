using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales
{
    public partial class update : Form
    {
        public update()
        {
           
            
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
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
            IList<Employee> ilst = NH.CreateCriteria(typeof(Employee)).Add(Restrictions.InsensitiveLike("EmpName", a, MatchMode.Anywhere)).List<Employee>();
            foreach (Employee pi in ilst)
            {
                string[] ro4 = new string[] { pi.EmpId.ToString(), pi.EmpName.ToString(), pi.EmpDesignation.ToString(), pi.EmpPhone.ToString(),pi.EmpAddress.ToString() };
                dataGridView1.Rows.Add(ro4);
            }
            //dataGridView13.DataSource = ilst;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label8.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {

                Employee ee = new Employee();

                ee.EmpName = textBox3.Text;
                ee.EmpPhone = textBox4.Text;
                ee.EmpId = Convert.ToInt32(label8.Text);
                ee.EmpAddress = textBox6.Text;
                ee.EmpDesignation = textBox5.Text;
                Login l = new Login();

                l.LoginPassword = textBox7.Text;
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NH.BeginTransaction())
                {

                    try
                    {

                        // ee.Login
                        NH.Update(ee);
                        l.LoginId = ee.EmpId;

                        NH.Update(l);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("INCOMPLETE TRANSACTION");
                        // throw ex;
                    }
                }
                label8.Text = "......";
                textBox7.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }
            else MessageBox.Show("SOMETTHING IS MISSING");
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            label8.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
        }
    }
}

