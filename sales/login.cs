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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //Program.emp = Convert.ToInt32(textBox1.Text);
                
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                Login l = new Login();
                IList<Login> ils = NHS.CreateCriteria(typeof(Login)).List<Login>();
                foreach (var log in ils)
                {
                    if (Convert.ToInt32(textBox1.Text) == log.LoginId)
                    {
                        Program.emp = Convert.ToInt32(textBox1.Text);

                        l = NHS.CreateCriteria(typeof(Login)).Add(Restrictions.Eq("LoginId", Program.emp)).UniqueResult<Login>();

                        break;
                    }
                }
                if (Program.emp > 0)
                {
                    if (l.LoginPassword == textBox2.Text)
                    {
                        sale sa = new sale();
                        sa.Show();
                        //this.Close() ;
                        this.Visible = false;
                    }
                    else
                        MessageBox.Show("Invaid Data");
                }
                else
                    MessageBox.Show("Invalid Employee_ID");

            }
            else MessageBox.Show("Incomplete");
        }
        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
