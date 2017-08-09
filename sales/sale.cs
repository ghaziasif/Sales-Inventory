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
using System.Drawing.Printing;



namespace sales
{
    public partial class sale : Form
    {
        public sale()
        {
            
            InitializeComponent();
        }

        Int32 indexRoww;
        Int32 indxRoww;
        Int32 indxRow;
        private void tabPage1_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void employee_entry()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.emp == 1)
            {
                if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox2.Text != "")
                {
                    Employee ee = new Employee();
                    ee.EmpName = textBox2.Text;
                    // ee.EmpId =Convert.ToInt32( textBox1.Text);
                    ee.EmpAddress = textBox3.Text;
                    ee.EmpDesignation = textBox4.Text;
                    ee.EmpPhone = textBox6.Text;
                    Login l = new Login();
                    l.LoginPassword = textBox5.Text;
                    nhgenerator.SF = sales.nhgenerator.GetSF();
                    ISession NHS = nhgenerator.SF.OpenSession();
                    using (ITransaction transaction = NHS.BeginTransaction())
                    {

                        try
                        {
                            NHS.Save(ee);
                            Employee ep = NHS.CreateCriteria(typeof(Employee)).AddOrder(Order.Desc("EmpId")).SetMaxResults(1).UniqueResult<Employee>();
                            l.LoginId = ep.EmpId;
                            NHS.Save(l);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            transaction.Rollback();
                            MessageBox.Show("Incomplete transaction");
                            // throw ex;
                        }
                    }
                }
                else MessageBox.Show("Incomplete");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NHS = nhgenerator.SF.OpenSession();
            IList<Employee> ils = NHS.CreateCriteria(typeof(Employee)).List<Employee>();
            dataGridView1.DataSource = ils;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
           // display_employee(); 
        }
     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.emp == 1)
            {
                update up = new update();
                up.Show();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
            {
                Customer cc = new Customer();
                // cc.CustomerId = Convert.ToInt32(textBox7.Text);
                cc.CustomerBalance = Convert.ToInt32(textBox11.Text);
                cc.CustomerName = textBox8.Text;
                cc.CustomerAddress = textBox10.Text;
                cc.CustomerPhoneNumber = textBox9.Text;

                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {

                    try
                    {

                        NHS.Save(cc);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                        //throw ex;
                    }
                }
            }
            else MessageBox.Show("Incomplete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NHS = nhgenerator.SF.OpenSession();
            IList<Customer> ils = NHS.CreateCriteria(typeof(Customer)).List<Customer>();
           
            dataGridView2.DataSource = ils;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.emp == 1)
            {
                updatecustomer f2 = new updatecustomer();
                f2.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "")
            {
                Supplier ss = new Supplier();
                //ss.SupplierId = Convert.ToInt32(textBox12.Text);
                ss.SupplierBalance = Convert.ToInt32(textBox16.Text);
                ss.SupplierName = textBox13.Text;
                ss.SupplierAddress = textBox15.Text;
                ss.SupplierPhoneNumber = textBox14.Text;

                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {

                    try
                    {

                        NHS.Save(ss);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();

                        throw ex;
                    }
                }
            }
            else MessageBox.Show("Incomplete");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NHS = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NHS.CreateCriteria(typeof(Supplier)).List<Supplier>();
            dataGridView3.DataSource = ils;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.AllowUserToAddRows = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Program.emp == 1)
            {
                supplierupdate f3 = new supplierupdate();
                f3.Show();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "")
            {
                Products pp = new Products();
                // pp.ProductId = Convert.ToInt32(textBox17.Text);
                pp.ProductPrice = Convert.ToInt32(textBox19.Text);
                pp.ProductName = textBox18.Text;
                pp.SalePrice = Convert.ToInt32(textBox20.Text);


                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {

                    try
                    {
                        NHS.Save(pp);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();

                        throw ex;
                    }
                }
            }
            else MessageBox.Show("Incomplete");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NHS = nhgenerator.SF.OpenSession();
            IList<Products> ils = NHS.CreateCriteria(typeof(Products)).List<Products>();
            dataGridView4.DataSource = ils;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.AllowUserToAddRows = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            updateproduct f4 = new updateproduct();
            f4.Show();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
            string a = textBox21.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Products> ils = NH.CreateCriteria(typeof(Products)).Add(Restrictions.InsensitiveLike("ProductName", a, MatchMode.Anywhere)).List<Products>();
            foreach (Products pi in ils)
            {
                string[] ro3 = new string[] { pi.ProductId.ToString(), pi.ProductName.ToString(), pi.ProductPrice.ToString(), pi.SalePrice.ToString() };
                dataGridView5.Rows.Add(ro3);
            }
           // dataGridView5.DataSource = ils;
            dataGridView5.AutoGenerateColumns = false;
            dataGridView5.AllowUserToAddRows = true;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void dataGridView5_DoubleClick(object sender, EventArgs e)
        {

        }

        private void textBox21_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView5_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
              nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            Stock st = NH.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(row.Cells[0].Value))).UniqueResult<Stock>();
            if (st != null)
            {
                if (st.Quantity != 0)
                {
                    string[] roww = new string[] { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), "1", (Convert.ToInt16(row.Cells[3].Value.ToString()) * 1).ToString() };
                    dataGridView6.Rows.Add(roww);
                }
                else
                    MessageBox.Show("OUT OF STOCK ");
            }
            else
                MessageBox.Show("OUT OF STOCK ");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }


        private void button13_Click(object sender, EventArgs e)
        {
            if ((textBox22.Text != "") && (textBox23.Text != ""))
            {
                DataGridViewRow newDataRow = dataGridView6.Rows[indexRoww];
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();
                Stock st = NH.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(newDataRow.Cells[0].Value))).UniqueResult<Stock>();
                if (Convert.ToInt32(textBox22.Text) <= st.Quantity)
                {//Int32 indexRow = e.RowIndex;

                    newDataRow.Cells[3].Value = textBox22.Text;
                    newDataRow.Cells[2].Value = textBox23.Text;
                    newDataRow.Cells[4].Value = (Convert.ToInt32(textBox22.Text) * Convert.ToInt16(textBox23.Text)).ToString();
                    textBox22.Text = "";
                    textBox23.Text = "";
                }
                else
                    MessageBox.Show("OUT of Stock");

            }
        }
        private void dataGridView6_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexRoww = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView6.Rows[indexRoww];

            textBox22.Text = row.Cells[3].Value.ToString();
            textBox23.Text = row.Cells[2].Value.ToString();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (indexRoww <= (dataGridView6.Rows.Count - 1))
            {
                DataGridViewRow row = dataGridView6.Rows[indexRoww];
                dataGridView6.Rows.Remove(row);
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            dataGridView7.Rows.Clear();
            string a = textBox24.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Customer> ils = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.InsensitiveLike("CustomerName", a, MatchMode.Anywhere)).List<Customer>();
            foreach (Customer pi in ils)
            {
                string[] ro2 = new string[] { pi.CustomerId.ToString(), pi.CustomerName.ToString(), pi.CustomerBalance.ToString(), pi.CustomerAddress.ToString(), pi.CustomerPhoneNumber.ToString() };
                dataGridView7.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView7.AutoGenerateColumns = false;
            dataGridView7.AllowUserToAddRows = true;
        }

        //private void sale_Load(object sender, EventArgs e)
        //{

        //    this.reportViewer1.RefreshReport();
        //}

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
           
            int totaly = 0;
            for (int i = 0; i < dataGridView6.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView6.Rows[i].Cells[4].Value);
            }
            label41.Text = totaly.ToString();
            if (String.IsNullOrEmpty(textBox28.Text))
                textBox28.Text = "0";
            if (label41.Text != "0" && label50.Text != "......" && textBox28.Text != "")
            {

                int billidd;
                Bill b = new Bill();
                b.BillDate = DateTime.Today;
                int sum = 0;
                
                b.BillAmoountPaid = Convert.ToInt32(textBox28.Text);
                b.BillType = "sale";
                for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView6.Rows[i].Cells[4].Value);
                }
                b.BillAmount = sum;

                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(b);
                        billidd = b.BillId;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        goto labe;
                        //throw ex;
                    }
                }
                for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                {
                    // nhgenerator.SF = sales.nhgenerator.GetSF();
                    ISession NHSS = nhgenerator.SF.OpenSession();
                    Orderr oo = new Orderr();
                    var bily = NHSS.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                    Stock st = new Stock();

                    //var bil = NHSS.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", 2)).UniqueResult<Bill>();
                    oo.Bill = bily;

                    var po = NHSS.CreateCriteria(typeof(Products)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(dataGridView6.Rows[i].Cells[0].Value))).UniqueResult<Products>();

                    oo.Products = po;
                    st.ProductId = po.ProductId;
                    oo.Quantity = Convert.ToInt32(dataGridView6.Rows[i].Cells[3].Value);
                    oo.Price = Convert.ToInt32(dataGridView6.Rows[i].Cells[2].Value);
                    oo.Total = Convert.ToInt32(dataGridView6.Rows[i].Cells[4].Value);
                    st = NHSS.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", po.ProductId)).UniqueResult<Stock>();

                    st.Quantity = st.Quantity - oo.Quantity;


                    Customer stu = NHSS.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Int32.Parse(label50.Text))).UniqueResult<Customer>();
                    oo.Customer = stu;

                    Employee empp = NHSS.CreateCriteria(typeof(Employee)).Add(Restrictions.Eq("EmpId", Program.emp)).UniqueResult<Employee>();

                    oo.Employee = empp;

                    using (ITransaction transaction = NHSS.BeginTransaction())
                    {

                        try
                        {
                            NHSS.Save(oo);
                            //      NHSS.Update(stu);
                            NHSS.Update(st);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            dele();
                            MessageBox.Show("Incomplete Transaction");
                            goto labe;
                            //throw ex;
                        }
                    }
                }

                ISession NH = nhgenerator.SF.OpenSession();
                CustomerRecord cr = new CustomerRecord();
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {

                        cr.Bill = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                        Customer c = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Int32.Parse(label50.Text))).UniqueResult<Customer>();
                        cr.Customer = c;
                        c.CustomerBalance = c.CustomerBalance + Int32.Parse(label41.Text);
                        if (String.IsNullOrEmpty(textBox28.Text))
                            textBox28.Text = "0";
                        if (Int32.Parse(textBox28.Text) >= 0)
                            c.CustomerBalance = c.CustomerBalance - Int32.Parse(textBox28.Text);
                        NH.Update(c);
                        NH.Save(cr);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        dele();
                        MessageBox.Show("Incomplete Transaction");
                        //throw ex;
                    }

                }
            labe: textBox22.Text = "";

            }
            else MessageBox.Show("Incomplete");
        }
        public void dele()
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            using (ITransaction transaction = NH.BeginTransaction())
            {
                var bily = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill", bily)).List<Orderr>();
                foreach (var orderr in ils)
                {
                    NH.Delete(orderr);
                    //Session.Delete(customer);
                }
                Bill bi = NH.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", bily.BillId)).UniqueResult<Bill>();
                NH.Delete(bi);
                transaction.Commit();
            }
        }
         
     

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox28_Validating(object sender, CancelEventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
           
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox28_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            dataGridView12.Rows.Clear();
            string a = textBox36.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Products> ils = NH.CreateCriteria(typeof(Products)).Add(Restrictions.InsensitiveLike("ProductName", a, MatchMode.Anywhere)).List<Products>();
            foreach (Products pi in ils)
            {
                string[] ro2 = new string[] { pi.ProductId.ToString(), pi.ProductName.ToString(), pi.ProductPrice.ToString(), pi.SalePrice.ToString() };
                dataGridView12.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView12.AutoGenerateColumns =false;
            dataGridView12.AllowUserToAddRows = true;
        
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            dataGridView10.Rows.Clear();
            string a = textBox33.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.InsensitiveLike("SupplierName", a, MatchMode.Anywhere)).List<Supplier>();
            foreach (Supplier pi in ils)
            {
                string[] ro2 = new string[] { pi.SupplierId.ToString(), pi.SupplierName.ToString(), pi.SupplierBalance.ToString(), pi.SupplierAddress.ToString(), pi.SupplierPhoneNumber.ToString() };
                dataGridView10.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView10.AutoGenerateColumns = false;
            dataGridView10.AllowUserToAddRows = true;
        }

       

        private void dataGridView12_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView12_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView12.Rows[e.RowIndex];
            string[] roww = new string[] { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), "1", (Convert.ToInt16(row.Cells[3].Value.ToString()) * 1).ToString() };
            dataGridView11.Rows.Add(roww);
        }

        private void dataGridView11_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indxRoww = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView11.Rows[indxRoww];

            textBox35.Text = row.Cells[3].Value.ToString();
            textBox34.Text = row.Cells[2].Value.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if ((textBox34.Text != "") && (textBox35.Text != ""))
            {  //Int32 indexRow = e.RowIndex;
                DataGridViewRow newDataRow = dataGridView11.Rows[indxRoww];
                newDataRow.Cells[3].Value = textBox35.Text;
                newDataRow.Cells[2].Value = textBox34.Text;
                newDataRow.Cells[4].Value = (Convert.ToInt32(textBox35.Text) * Convert.ToInt16(textBox34.Text)).ToString();
                textBox34.Text = "";
                textBox35.Text = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (indxRoww <= (dataGridView11.Rows.Count - 1))
            {
                DataGridViewRow row = dataGridView11.Rows[indxRoww];
                dataGridView11.Rows.Remove(row);
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView6.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView6.Rows[i].Cells[4].Value);
            }
            label41.Text = totaly.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView11.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView11.Rows[i].Cells[4].Value);
            }
            label42.Text = totaly.ToString();
            if (String.IsNullOrEmpty(textBox29.Text))
                textBox29.Text = "0";

            if (label42.Text != "0" && label51.Text != "......" && textBox29.Text != "")
            {

                Purchase p = new Purchase();
                p.PurchaseDate = DateTime.Today;
                int sum = 0;
                p.PurchaseAmountPaid = Convert.ToInt32(textBox29.Text);
                p.PurchaseType = "purchase";
                for (int i = 0; i < dataGridView11.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView11.Rows[i].Cells[4].Value);
                }
                p.TotalBill = sum;
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(p);



                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                        goto labell;
                        //throw ex;
                    }
                }
                for (int i = 0; i < dataGridView11.Rows.Count; ++i)
                {
                    // nhgenerator.SF = sales.nhgenerator.GetSF();
                    ISession NHSS = nhgenerator.SF.OpenSession();
                    PurchaseOrder po = new PurchaseOrder();
                    //Stock st = new Stock();
                    var par = NHSS.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();

                    po.Purchase = par;
                    po.Quantity = Convert.ToInt32(dataGridView11.Rows[i].Cells[3].Value);

                    var pro = NHSS.CreateCriteria(typeof(Products)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(dataGridView11.Rows[i].Cells[0].Value))).UniqueResult<Products>();

                    po.Products = pro;

                    Stock st = NHSS.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", pro.ProductId)).UniqueResult<Stock>();
                    Stock stk = new Stock();
                    if (st == null)
                    {


                        stk.ProductId = pro.ProductId;
                        stk.Quantity = po.Quantity;
                        st = stk;
                    }
                    else
                        st.Quantity = st.Quantity + po.Quantity;


                    po.Price = Convert.ToInt32(dataGridView11.Rows[i].Cells[2].Value);
                    po.Total = Convert.ToInt32(dataGridView11.Rows[i].Cells[4].Value);

                    Supplier sup = NHSS.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Int32.Parse(label51.Text))).UniqueResult<Supplier>();
                    po.Supplier = sup;

                    Employee empp = NHSS.CreateCriteria(typeof(Employee)).Add(Restrictions.Eq("EmpId", Program.emp)).UniqueResult<Employee>();

                    po.Employee = empp;
                    //emp.EmpId;

                    using (ITransaction transaction = NHSS.BeginTransaction())
                    {

                        try
                        {
                            NHSS.Save(po);
                            //      NHSS.Update(stu);
                            NHSS.SaveOrUpdate(st);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            delet();
                            MessageBox.Show("Incomplete Transaction");
                            goto labell;
                            //throw ex;
                        }
                    }
                }

                ISession NH = nhgenerator.SF.OpenSession();
                SupplierRecord sr = new SupplierRecord();
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {

                        sr.Purchase = NH.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                        Supplier s = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Int32.Parse(label51.Text))).UniqueResult<Supplier>();
                        sr.Supplier = s;
                        s.SupplierBalance = s.SupplierBalance + Int32.Parse(label42.Text);
                        if (String.IsNullOrEmpty(textBox29.Text))
                            textBox29.Text = "0";
                        if (Int32.Parse(textBox29.Text) >= 0)
                            s.SupplierBalance = s.SupplierBalance - Int32.Parse(textBox29.Text);

                        NH.Update(s);
                        NH.Save(sr);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        delet();
                        MessageBox.Show("Incomplete Transaction");
                        //throw ex;
                    }

                }
            labell:
                textBox22.Text = "";

            }
            else
                MessageBox.Show("Incomplete");
        }
        public void delet()
        {
           nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            using (ITransaction transaction = NH.BeginTransaction())
            { 
                var pur = NH.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                IList<PurchaseOrder> ils = NH.CreateCriteria(typeof(PurchaseOrder)).Add(Restrictions.Eq("PurchaseId", pur)).List<PurchaseOrder>();
                foreach (var orderr in ils)
                {
                    NH.Delete(orderr);
                    //Session.Delete(customer);
                }
                Purchase p = NH.CreateCriteria(typeof(Purchase)).Add(Restrictions.Eq("PurchaseId", pur.PurchaseId)).UniqueResult<Purchase>();
                NH.Delete(p);
                transaction.Commit();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView11.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView11.Rows[i].Cells[4].Value);
            }
            label42.Text = totaly.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            dataGridView13.Rows.Clear();
            string a = textBox37.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Products> ilst = NH.CreateCriteria(typeof(Products)).Add(Restrictions.InsensitiveLike("ProductName", a, MatchMode.Anywhere)).List<Products>();
            foreach (Products pi in ilst)
            {
                string[] ro4 = new string[] { pi.ProductId.ToString(), pi.ProductName.ToString(), pi.ProductPrice.ToString(), pi.SalePrice.ToString() };
                dataGridView13.Rows.Add(ro4);
            }
            //dataGridView13.DataSource = ilst;
            dataGridView13.AutoGenerateColumns = true;
            dataGridView13.AllowUserToAddRows = true;
            
            
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView13_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            indxRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView13.Rows[indxRow];
           Stock s= NH.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(row.Cells[0].Value))).UniqueResult<Stock>();
           if (s != null)
               label45.Text = s.Quantity.ToString();
           else
               label45.Text = ".....";
        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void textBox38_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();
            
            string a = textBox38.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Products> ils = NH.CreateCriteria(typeof(Products)).Add(Restrictions.InsensitiveLike("ProductName", a, MatchMode.Anywhere)).List<Products>();
           foreach(Products pi in ils)
           {
            string[] ro1 = new string[] {pi.ProductId.ToString(),pi.ProductName.ToString(),pi.ProductPrice.ToString(),pi.SalePrice.ToString() };
            dataGridView14.Rows.Add(ro1);
            }
            //dataGridView14.DataSource = ils;
            dataGridView14.AutoGenerateColumns = false;
            dataGridView14.AllowUserToAddRows = false;
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            dataGridView16.Rows.Clear();
            string a = textBox43.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.InsensitiveLike("SupplierName", a, MatchMode.Anywhere)).List<Supplier>();
            foreach (Supplier pi in ils)
            {
                string[] ro2 = new string[] { pi.SupplierId.ToString(), pi.SupplierName.ToString(), pi.SupplierBalance.ToString(), pi.SupplierAddress.ToString(), pi.SupplierPhoneNumber.ToString() };
                dataGridView16.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView16.AutoGenerateColumns = false;
            dataGridView16.AllowUserToAddRows = true;
        }

    

        private void dataGridView14_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView14.Rows[e.RowIndex];
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            Stock st = NH.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(row.Cells[0].Value))).UniqueResult<Stock>();
            if (st != null)
            {
                if (st.Quantity != 0)
                {

                    string[] roww = new string[] { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), "1", (Convert.ToInt16(row.Cells[3].Value.ToString()) * 1).ToString() };
                    dataGridView17.Rows.Add(roww);
                }
                else MessageBox.Show("OUT of STOCK");
            }else 
                MessageBox.Show("OUT of STOCK");
        }

        private void dataGridView14_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView16_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView16.Rows[e.RowIndex];
            label61.Text = row.Cells[0].Value.ToString();
        }

        //private void dataGridView15_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridViewRow row = this.dataGridView15.Rows[e.RowIndex];
        //    textBox41.Text = row.Cells[0].Value.ToString();
        //}

        private void button22_Click_1(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView17.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView17.Rows[i].Cells[4].Value);
            }
            label47.Text = totaly.ToString();
        }
Int32 ramm;       
        private void dataGridView17_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            ramm=e.RowIndex;
            DataGridViewRow row = this.dataGridView17.Rows[e.RowIndex];
            textBox44.Text = row.Cells[2].Value.ToString();
            textBox45.Text = row.Cells[3].Value.ToString();
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if ((textBox44.Text != "") && (textBox45.Text != ""))
            {
                DataGridViewRow newDataRow = dataGridView17.Rows[ramm];
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();
                Stock st = NH.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(newDataRow.Cells[0].Value))).UniqueResult<Stock>();
                if (Convert.ToInt32(textBox45.Text) <= st.Quantity)
                {
                    newDataRow.Cells[3].Value = textBox45.Text;
                    newDataRow.Cells[2].Value = textBox44.Text;
                    newDataRow.Cells[4].Value = (Convert.ToInt32(textBox44.Text) * Convert.ToInt16(textBox45.Text)).ToString();
                    textBox44.Text = "";
                    textBox45.Text = "";
                }
                else
                    MessageBox.Show("Out of Stock");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (ramm <= (dataGridView17.Rows.Count - 1))
            {
                DataGridViewRow row = dataGridView17.Rows[ramm];
                dataGridView17.Rows.Remove(row);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView17.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView17.Rows[i].Cells[4].Value);
            }
            label47.Text = totaly.ToString();
            if (String.IsNullOrEmpty(textBox39.Text))
                textBox39.Text = "0";
            if (label47.Text != "0" && label61.Text != "......" && textBox39.Text != "")
            {
                Purchase p = new Purchase();
                p.PurchaseDate = DateTime.Today;
                int sum = 0;

                p.PurchaseAmountPaid = Convert.ToInt32(textBox39.Text);

                for (int i = 0; i < dataGridView17.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView17.Rows[i].Cells[4].Value);
                }
                p.TotalBill = sum;
                p.PurchaseType = "return";
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(p);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                        goto labellx;
                        //throw ex;
                    }
                }
                for (int i = 0; i < dataGridView17.Rows.Count; ++i)
                {
                    // nhgenerator.SF = sales.nhgenerator.GetSF();
                    ISession NHSS = nhgenerator.SF.OpenSession();
                    PurchaseOrder po = new PurchaseOrder();
                    //Stock st = new Stock();
                    var par = NHSS.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();

                    po.Purchase = par;
                    po.Quantity = Convert.ToInt32(dataGridView17.Rows[i].Cells[3].Value);

                    var pro = NHSS.CreateCriteria(typeof(Products)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(dataGridView17.Rows[i].Cells[0].Value))).UniqueResult<Products>();

                    po.Products = pro;

                    Stock st = NHSS.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", pro.ProductId)).UniqueResult<Stock>();
                    st.Quantity = st.Quantity - po.Quantity;


                    po.Price = Convert.ToInt32(dataGridView17.Rows[i].Cells[2].Value);
                    po.Total = Convert.ToInt32(dataGridView17.Rows[i].Cells[4].Value);

                    Supplier sup = NHSS.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Int32.Parse(label61.Text))).UniqueResult<Supplier>();
                    po.Supplier = sup;

                    Employee empp = NHSS.CreateCriteria(typeof(Employee)).Add(Restrictions.Eq("EmpId", Program.emp)).UniqueResult<Employee>();

                    po.Employee = empp;
                    //emp.EmpId;

                    using (ITransaction transaction = NHSS.BeginTransaction())
                    {

                        try
                        {
                            NHSS.Save(po);
                            //      NHSS.Update(stu);
                            NHSS.SaveOrUpdate(st);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            DeletePurchaseReturnOnException();
                            MessageBox.Show("Incomplete Transaction");
                            goto labellx;
                            //throw ex;
                        }
                    }
                }

                ISession NH = nhgenerator.SF.OpenSession();
                SupplierRecord sr = new SupplierRecord();
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {

                        sr.Purchase = NH.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                        Supplier s = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Int32.Parse(label61.Text))).UniqueResult<Supplier>();
                        sr.Supplier = s;
                        s.SupplierBalance = s.SupplierBalance - Int32.Parse(label47.Text);
                        if (String.IsNullOrEmpty(textBox39.Text))
                            textBox29.Text = "0";
                        if (Int32.Parse(textBox39.Text) >= 0)
                            s.SupplierBalance = s.SupplierBalance + Int32.Parse(textBox39.Text);

                        NH.Update(s);
                        NH.Save(sr);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        DeletePurchaseReturnOnException();
                        MessageBox.Show("Incomplete Transaction");
                        //throw ex;
                    }

                }
            labellx:
                textBox22.Text = "";

            }
            else MessageBox.Show("Incomplete");
        }
        public void  DeletePurchaseReturnOnException()
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            using (ITransaction transaction = NH.BeginTransaction())
            {
                var pur = NH.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                IList<PurchaseOrder> ils = NH.CreateCriteria(typeof(PurchaseOrder)).Add(Restrictions.Eq("PurchaseId", pur)).List<PurchaseOrder>();
                foreach (var orderr in ils)
                {
                    NH.Delete(orderr);
                    //Session.Delete(customer);
                }
                Purchase p = NH.CreateCriteria(typeof(Purchase)).Add(Restrictions.Eq("PurchaseId", pur.PurchaseId)).UniqueResult<Purchase>();
                NH.Delete(p);
                transaction.Commit();
            }
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox46_Enter(object sender, EventArgs e)
        {
           
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            dataGridView18.Rows.Clear();
            string a = textBox46.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            Bill bil = NH.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", Int32.Parse(a))).UniqueResult<Bill>();
            if (bil != null)
            {

                  IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill.BillId", bil.BillId)).List<Orderr>();
                  foreach (var ee in ils)
                  {
                      string[] roww = new string[] { ee.OrderId.ToString(), ee.Employee.EmpId.ToString(), ee.Customer.CustomerId.ToString(), ee.Bill.BillId.ToString(), ee.Products.ProductId.ToString(),ee.Products.ProductName.ToString(), ee.Quantity.ToString(), ee.Price.ToString(), ee.Total.ToString() };
                      dataGridView18.Rows.Add(roww);
                  }
               }
            else
                MessageBox.Show("Invalid Bill Id");
        }
       // Int32 rowtarget;
        private void dataGridView18_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    rowtarget = e.RowIndex;

            DataGridViewRow row = this.dataGridView18.Rows[e.RowIndex];
            if (Convert.ToInt32(row.Cells[0].Value) != 0)
            {
                string[] roww = new string[] { row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[6].Value.ToString(), (Convert.ToInt32(row.Cells[7].Value.ToString()) * Convert.ToInt32(row.Cells[6].Value.ToString())).ToString() };
            
                dataGridView19.Rows.Add(roww);
                label59.Text = row.Cells[2].Value.ToString();
            }
            
        }

        private void label56_Click(object sender, EventArgs e)
        {

        }
        Int32 rowtarget;
        private void dataGridView19_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowtarget = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView19.Rows[rowtarget];

            textBox48.Text = row.Cells[3].Value.ToString();
            textBox47.Text = row.Cells[2].Value.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {

            if ((rowtarget <= (dataGridView19.Rows.Count - 1)) && (textBox48.Text != "") && (textBox47.Text != ""))
            {
                DataGridViewRow newDataRow = dataGridView19.Rows[rowtarget];
                newDataRow.Cells[3].Value = textBox48.Text;
                newDataRow.Cells[2].Value = textBox47.Text;
                newDataRow.Cells[4].Value = (Convert.ToInt32(textBox47.Text) * Convert.ToInt16(textBox48.Text)).ToString();
                textBox47.Text = "";
                textBox48.Text = "";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
                if (rowtarget <= (dataGridView19.Rows.Count-1))
                {
                    DataGridViewRow row = dataGridView19.Rows[rowtarget];
                    dataGridView19.Rows.Remove(row);
                }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView19.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView19.Rows[i].Cells[4].Value);
            }
            label56.Text = totaly.ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int totaly = 0;
            for (int i = 0; i < dataGridView19.Rows.Count; ++i)
            {
                totaly += Convert.ToInt32(dataGridView19.Rows[i].Cells[4].Value);
            }
            label56.Text = totaly.ToString();
            if (String.IsNullOrEmpty(textBox50.Text))
                textBox50.Text = "0";
            if (label56.Text != "0" && textBox50.Text != "" && label59.Text != "")
            {
                int billidd;
                Bill b = new Bill();
                b.BillDate = DateTime.Today;
                int sum = 0;

                b.BillAmoountPaid = Convert.ToInt32(textBox50.Text);

                for (int i = 0; i < dataGridView19.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView19.Rows[i].Cells[4].Value);
                }
                b.BillAmount = sum;
                b.BillType = textBox46.Text+"  Return";
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(b);
                        billidd = b.BillId;


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        goto lbe;
                        //throw ex;
                    }
                }
                for (int i = 0; i < dataGridView19.Rows.Count; ++i)
                {
                    // nhgenerator.SF = sales.nhgenerator.GetSF();
                    ISession NHSS = nhgenerator.SF.OpenSession();
                    Orderr oo = new Orderr();
                    var bily = NHSS.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                    Stock st = new Stock();

                    //var bil = NHSS.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", 2)).UniqueResult<Bill>();
                    oo.Bill = bily;

                    var po = NHSS.CreateCriteria(typeof(Products)).Add(Restrictions.Eq("ProductId", Convert.ToInt32(dataGridView19.Rows[i].Cells[0].Value))).UniqueResult<Products>();

                    oo.Products = po;
                    st.ProductId = po.ProductId;
                    oo.Quantity = Convert.ToInt32(dataGridView19.Rows[i].Cells[3].Value);
                    oo.Price = Convert.ToInt32(dataGridView19.Rows[i].Cells[2].Value);
                    oo.Total = Convert.ToInt32(dataGridView19.Rows[i].Cells[4].Value);
                    st = NHSS.CreateCriteria(typeof(Stock)).Add(Restrictions.Eq("ProductId", po.ProductId)).UniqueResult<Stock>();

                    st.Quantity = st.Quantity + oo.Quantity;


                    Customer stu = NHSS.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Int32.Parse(label59.Text))).UniqueResult<Customer>();
                    oo.Customer = stu;

                    Employee empp = NHSS.CreateCriteria(typeof(Employee)).Add(Restrictions.Eq("EmpId", Program.emp)).UniqueResult<Employee>();

                    oo.Employee = empp;

                    using (ITransaction transaction = NHSS.BeginTransaction())
                    {

                        try
                        {
                            NHSS.Save(oo);
                            //      NHSS.Update(stu);
                            NHSS.Update(st);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            DeleteSaleReturnOnException();
                            MessageBox.Show("Incomplete Transaction");
                            goto lbe;
                            //throw ex;
                        }
                    }
                }

                ISession NH = nhgenerator.SF.OpenSession();
                CustomerRecord cr = new CustomerRecord();
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {

                        cr.Bill = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                        Customer c = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Int32.Parse(label59.Text))).UniqueResult<Customer>();
                        cr.Customer = c;
                        c.CustomerBalance = c.CustomerBalance - Int32.Parse(label56.Text);
                        if (String.IsNullOrEmpty(textBox50.Text))
                            textBox50.Text = "0";
                        if (Int32.Parse(textBox50.Text) >= 0)
                            c.CustomerBalance = c.CustomerBalance + Int32.Parse(textBox50.Text);
                        NH.Update(c);
                        NH.Save(cr);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        DeleteSaleReturnOnException();
                        MessageBox.Show("Incomplete Transaction");
                        //throw ex;
                    }

                }
            lbe: textBox22.Text = "";
            }
            else MessageBox.Show("Incomplete");
        }
        public void DeleteSaleReturnOnException()
        {
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            using (ITransaction transaction = NH.BeginTransaction())
            {
                var bily = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill", bily)).List<Orderr>();
                foreach (var orderr in ils)
                {
                    NH.Delete(orderr);
                    //Session.Delete(customer);
                }
                Bill bi = NH.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", bily.BillId)).UniqueResult<Bill>();
                NH.Delete(bi);
                transaction.Commit();
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView18_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            string a = textBox25.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Customer> ils = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.InsensitiveLike("CustomerName", a, MatchMode.Anywhere)).List<Customer>();
         
          
            dataGridView8.DataSource = ils;
            dataGridView8.AutoGenerateColumns = false;
            dataGridView8.AllowUserToAddRows = true;
        }

        private void dataGridView8_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView9.Rows.Clear();
            DataGridViewRow row = this.dataGridView8.Rows[e.RowIndex];
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<CustomerRecord> ils = NH.CreateCriteria(typeof(CustomerRecord)).Add(Restrictions.Eq("Customer.CustomerId", Convert.ToInt32(row.Cells["CustomerId"].Value))).List<CustomerRecord>();
            if (ils != null)
            {

                //IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill.BillId", bil.BillId)).List<Orderr>();
                foreach (var ee in ils)
                {
                    Bill b = new Bill();
                    b = NH.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", ee.Bill.BillId)).UniqueResult<Bill>();
                    string[] roww = new string[] { ee.CustRecordId.ToString(), ee.Bill.BillId.ToString(), ee.Customer.CustomerName.ToString(), b.BillAmount.ToString(), b.BillAmoountPaid.ToString(), b.BillDate.ToString(), b.BillType.ToString() };
                    dataGridView9.Rows.Add(roww);
                }
            }
            else
                MessageBox.Show("This Customer has no record");
           // dataGridView9.DataSource = ils;
        }

        private void dataGridView9_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            dataGridView15.Rows.Clear();
            DataGridViewRow row = this.dataGridView9.Rows[e.RowIndex];
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            Bill bil = NH.CreateCriteria(typeof(Bill)).Add(Restrictions.Eq("BillId", Convert.ToInt32(row.Cells[1].Value))).UniqueResult<Bill>();
           

                IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill.BillId", bil.BillId)).List<Orderr>();
               
            foreach (var ee in ils)
                {
                    string[] roww = new string[] { ee.OrderId.ToString(), ee.Employee.EmpId.ToString(), ee.Customer.CustomerId.ToString(), ee.Products.ProductName.ToString(), ee.Quantity.ToString(), ee.Price.ToString(), ee.Total.ToString() };
                    dataGridView15.Rows.Add(roww);
                }
            
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {
            string a = textBox17.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.InsensitiveLike("SupplierName", a, MatchMode.Anywhere)).List<Supplier>();
           
            dataGridView22.DataSource = ils;
            dataGridView22.AutoGenerateColumns = true;
            dataGridView22.AllowUserToAddRows = true;
        }

        private void dataGridView22_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView21.Rows.Clear();
            DataGridViewRow row = this.dataGridView22.Rows[e.RowIndex];
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<SupplierRecord> ils = NH.CreateCriteria(typeof(SupplierRecord)).Add(Restrictions.Eq("Supplier.SupplierId", Convert.ToInt32(row.Cells["SupplierId"].Value))).List<SupplierRecord>();
            if (ils != null)
            {

                //IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill.BillId", bil.BillId)).List<Orderr>();
                foreach (var ee in ils)
                {
                    Purchase p = new Purchase();
                    p = NH.CreateCriteria(typeof(Purchase)).Add(Restrictions.Eq("PurchaseId", ee.Purchase.PurchaseId)).UniqueResult<Purchase>();
                    string[] roww = new string[] { ee.SupplierRecordId.ToString(), ee.Purchase.PurchaseId.ToString(), ee.Supplier.SupplierName.ToString(), p.TotalBill.ToString(), p.PurchaseAmountPaid.ToString(), p.PurchaseDate.ToString(), p.PurchaseType.ToString() };
                    dataGridView21.Rows.Add(roww);
                }
            }
            else
                MessageBox.Show("This Customer has no record");
        }

        private void dataGridView21_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView20.Rows.Clear();
            DataGridViewRow row = this.dataGridView21.Rows[e.RowIndex];
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            Purchase pur = NH.CreateCriteria(typeof(Purchase)).Add(Restrictions.Eq("PurchaseId", Convert.ToInt32(row.Cells[1].Value))).UniqueResult<Purchase>();


            IList<PurchaseOrder> ils = NH.CreateCriteria(typeof(PurchaseOrder)).Add(Restrictions.Eq("Purchase.PurchaseId", pur.PurchaseId)).List<PurchaseOrder>();

            foreach (var ee in ils)
            {
                string[] roww = new string[] { ee.PurchaseOrderId.ToString(), ee.Employee.EmpId.ToString(), ee.Supplier.SupplierName.ToString(), ee.Products.ProductName.ToString(), ee.Quantity.ToString(), ee.Price.ToString(), ee.Total.ToString() };
                dataGridView20.Rows.Add(roww);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }

        }

        private void button30_Click(object sender, EventArgs e)
        {
            dataGridView7.Rows.Clear();
            dataGridView6.Rows.Clear();
           // dataGridView7.Rows.Clear();
            textBox22.Text = "";
            textBox23.Text = "";
           // textBox27.Text = "";
            label50.Text = "......";
            textBox28.Text = "";
            textBox24.Text = "";
            textBox21.Text = "";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            dataGridView10.Rows.Clear();
            dataGridView11.Rows.Clear();
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            //textBox30.Text = "";
            label51.Text = "......";
            textBox29.Text = "";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            dataGridView16.Rows.Clear();
            dataGridView17.Rows.Clear();
            textBox38.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox39.Text = "";
            label61.Text = "......";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //Report rep = new Report();
            //rep.Show();
            PrintDialog pt = new PrintDialog();
            PrintDocument pd = new PrintDocument();
            pt.Document = pd;
            pd.PrintPage +=new PrintPageEventHandler(pd_PrintPage);
            DialogResult result = pt.ShowDialog();
            if(result==DialogResult.OK)
            {
                pd.Print();
            }
            
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics ggg = e.Graphics;
            Font fon = new Font("Courier New", 12);
            float fontHeight = fon.GetHeight();
            int stax = 30;
            int stay = 30;
            int offsett = 40;
            ggg.DrawString("Ghazi Professional", new Font(" Courier New", 18), new SolidBrush(Color.Black), stax, stay);
          
            offsett = offsett + (int)fontHeight + 5;

            Orderr ooi = new Orderr();
            ISession NH = nhgenerator.SF.OpenSession();
            
            var bil = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
            string linerr ="Bill Number:  "+ bil.BillId.ToString();
          ggg.DrawString(linerr, Font, new SolidBrush(Color.Black), stax, stay + offsett);
          offsett = offsett + (int)fontHeight + 10;
            IList<Orderr> ils = NH.CreateCriteria(typeof(Orderr)).Add(Restrictions.Eq("Bill", bil)).List<Orderr>();
           int totp=0;
            Customer oy =new Customer();
            foreach(Orderr  oe in ils  )
            {
                string productid =  "Product ID: "+oe.Products.ProductId.ToString(); 
                string ProductName= "      Name:   "+oe.Products.ProductName+"                 ";
                string linerrr =productid + ProductName;
                ggg.DrawString(linerrr, Font, new SolidBrush(Color.Black), stax, stay + offsett);
                offsett = offsett + (int)fontHeight + 5;
                string quantity = oe.Quantity.ToString()+"  X  ";
                   string prixe=oe.Price.ToString()+"  =     ";
                   string tot = oe.Total.ToString();
                string liner= quantity+prixe+tot;
               ggg.DrawString(liner, Font, new SolidBrush(Color.Black), stax, stay + offsett);
                offsett = offsett + (int)fontHeight + 5;
               totp +=Convert.ToInt32(oe.Total);
               oy = oe.Customer;
            }
            offsett = offsett + 20;
          
            ggg.DrawString("Total To Pay".PadRight(30) + String.Format("{0:c}", bil.BillAmount), Font, new SolidBrush(Color.Black), stax, stay + offsett);
            offsett = offsett + (int)fontHeight + 10;
            ggg.DrawString("Total Paid".PadRight(30) + String.Format("{0:c}",bil.BillAmoountPaid), Font, new SolidBrush(Color.Black), stax, stay + offsett);
            offsett = offsett + (int)fontHeight + 10; 
            
            ggg.DrawString("Customer Balance".PadRight(30) + String.Format("{0:c}",oy.CustomerBalance ), Font, new SolidBrush(Color.Black), stax, stay + offsett);

            offsett = offsett + 20;
            //Bitmap bm = new Bitmap(this.dataGridView6.Width, this.dataGridView6.Height);
            //dataGridView6.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView6.Width, this.dataGridView6.Height));
            //e.Graphics.DrawImage(bm, 10, 400);
        }

       

        private void dataGridView14_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView23.Rows.Clear();
            string a = textBox1.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Customer> ils = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.InsensitiveLike("CustomerName", a, MatchMode.Anywhere)).List<Customer>();
            foreach (Customer pi in ils)
            {
                string[] ro2 = new string[] { pi.CustomerId.ToString(), pi.CustomerName.ToString(), pi.CustomerBalance.ToString(), pi.CustomerAddress.ToString(),pi.CustomerPhoneNumber.ToString() };
                dataGridView23.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView23.AutoGenerateColumns = false;
            dataGridView23.AllowUserToAddRows = true;
        
        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            if ((label36.Text != "......") && (textBox12.Text != ""))
            {
                int oke = 1;
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                CustomerRecord crec = new CustomerRecord();
                Bill bm = new Bill();
                bm.BillAmount = Convert.ToInt32(textBox12.Text);
                bm.BillDate = DateTime.Today;
                bm.BillType = "Payment";
                bm.BillAmoountPaid = Convert.ToInt32(textBox12.Text);
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(bm);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                        goto olay;
                    }
                }
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();

                crec.Bill = NH.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                crec.Customer = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Convert.ToInt32(label36.Text))).UniqueResult<Customer>();
                Customer cr = NH.CreateCriteria(typeof(Customer)).Add(Restrictions.Eq("CustomerId", Convert.ToInt32(label36.Text))).UniqueResult<Customer>();
                cr.CustomerBalance = cr.CustomerBalance - Convert.ToInt32(textBox12.Text);
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {
                        NH.Update(cr);
                        NH.Save(crec);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Bill bb = NHS.CreateCriteria(typeof(Bill)).AddOrder(Order.Desc("BillId")).SetMaxResults(1).UniqueResult<Bill>();
                        NH.Delete(bb);
                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                    }
                }
            olay: oke = 2;



            }
        }

        private void dataGridView23_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView23.Rows[e.RowIndex];
            
            label36.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];

            label50.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView10_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView10.Rows[e.RowIndex];

            label51.Text = row.Cells[0].Value.ToString();
        }

        private void textBox26_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView24.Rows.Clear();
            string a = textBox26.Text;
            nhgenerator.SF = sales.nhgenerator.GetSF();
            ISession NH = nhgenerator.SF.OpenSession();
            IList<Supplier> ils = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.InsensitiveLike("SupplierName", a, MatchMode.Anywhere)).List<Supplier>();
            foreach (Supplier pi in ils)
            {
                string[] ro2 = new string[] { pi.SupplierId.ToString(), pi.SupplierName.ToString(), pi.SupplierBalance.ToString(), pi.SupplierAddress.ToString(), pi.SupplierPhoneNumber.ToString() };
                dataGridView24.Rows.Add(ro2);
            }
            //dataGridView12.DataSource = ils;
            dataGridView24.AutoGenerateColumns = false;
            dataGridView24.AllowUserToAddRows = true;
        }

        private void dataGridView24_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView24.Rows[e.RowIndex];

            label63.Text = row.Cells[0].Value.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if ((label63.Text != "......") && (textBox7.Text != ""))
            {
                int okee = 1;
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NHS = nhgenerator.SF.OpenSession();
                SupplierRecord srec = new SupplierRecord();
                Purchase bm = new Purchase();
                bm.TotalBill = Convert.ToInt32(textBox7.Text);
                bm.PurchaseDate = DateTime.Today;
                bm.PurchaseType = "Payment";
                bm.PurchaseAmountPaid = Convert.ToInt32(textBox7.Text);
                using (ITransaction transaction = NHS.BeginTransaction())
                {
                    try
                    {
                        NHS.Save(bm);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                        goto opay;
                    }
                }
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();

                srec.Purchase = NH.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                srec.Supplier = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Convert.ToInt32(label63.Text))).UniqueResult<Supplier>();
                Supplier sr = NH.CreateCriteria(typeof(Supplier)).Add(Restrictions.Eq("SupplierId", Convert.ToInt32(label63.Text))).UniqueResult<Supplier>();
                sr.SupplierBalance = sr.SupplierBalance - Convert.ToInt32(textBox7.Text);
                using (ITransaction transaction = NH.BeginTransaction())
                {
                    try
                    {
                        NH.Update(sr);
                        NH.Save(srec);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Purchase pp = NHS.CreateCriteria(typeof(Purchase)).AddOrder(Order.Desc("PurchaseId")).SetMaxResults(1).UniqueResult<Purchase>();
                        NH.Delete(pp);
                        transaction.Rollback();
                        MessageBox.Show("Incomplete Transaction");
                    }
                }
            opay: okee = 2;

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (Program.emp == 1)
            {
                dataGridView25.Rows.Clear();
                nhgenerator.SF = sales.nhgenerator.GetSF();
                ISession NH = nhgenerator.SF.OpenSession();

                int totaly = 0;
                IList<Bill> ilst = NH.CreateCriteria<Bill>().Add(Restrictions.Between("BillDate", dateTimePicker1.Value, dateTimePicker2.Value)).List<Bill>();
                foreach (Bill po in ilst)
                {

                    string[] roww = new string[] { po.BillId.ToString(), po.BillDate.ToString(), po.BillType.ToString(), po.BillAmount.ToString(), po.BillAmoountPaid.ToString() };
                    dataGridView25.Rows.Add(roww);
                    if (po.BillType == "sale")
                    {
                        totaly = totaly + Convert.ToInt32(po.BillAmount);
                    }
                }



                label68.Text = totaly.ToString();
            }
        }

        

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click_1(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged_2(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(currenttb.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                currenttb.Text = currenttb.Text.Remove(currenttb.Text.Length - 1);
            }
        }
    }
}
