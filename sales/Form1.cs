using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
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
    public partial class Form1 : Form
    {
        //private Configuration myConfiguration;
        //private ISessionFactory mySessionFactory;
        //private ISession mySession;
       
        public Form1()
        {
            
            InitializeComponent();
             
        }
       
        private void GetPlayerInfo()
        {
            
              nhgenerator.SF = sales.nhgenerator.GetSF();
              ISession NHS = nhgenerator.SF.OpenSession();

                     IList<Employee> ils = NHS.CreateCriteria(typeof(Employee)).List<Employee>();
            listBox1.DataSource = ils;
            listBox1.ValueMember = "EmpId";
            listBox1.DisplayMember = "EmpId";
            //EmpName
                listBox2.DataSource = ils;
            listBox2.ValueMember = "EmpId";
            listBox2.DisplayMember = "EmpName";
            dataGridView1.DataSource = ils;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;


            NHS.Dispose();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                GetPlayerInfo();

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
