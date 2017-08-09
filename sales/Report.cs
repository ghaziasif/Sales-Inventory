using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Transform;
namespace sales
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"G:\semester 6\SE\sales\sales\CrystalReport1.rpt");
            //nhgenerator.SF = sales.nhgenerator.GetSF();
            //ISession NH = nhgenerator.SF.OpenSession();
            //IList<Bill> datas = NH.CreateCriteria(typeof(Bill)).List<Bill>();
            //if(datas!=null)
            //cryRpt.SetDataSource(datas);

            crystalReportViewer1.ReportSource = cryRpt;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    nhgenerator.SF = sales.nhgenerator.GetSF();
        //    ISession NH = nhgenerator.SF.OpenSession();
        //    IList<Bill> datas =  NH.CreateCriteria(typeof(Bill)).List<Bill>();
        //    ReportDocument RD = new ReportDocument();
            
            //RD.SetDataSource(datas);

            //crystalReportViewer1.ReportSource = RD;
            //    ReportDocument cryRpt = new ReportDocument();
        //    cryRpt.Load(@"G:\semester 6\SE\sales\sales\CrystalReport1.rpt");
        //    crystalReportViewer1.ReportSource = cryRpt;
          
           // ReportDocument rDoc = new ReportDocument();
            //DataSet1 dset = new DataSet1(); // dataset file name
            //DataTable dtable = new DataTable(); // data table name
            
            //dtable.TableName = "DataTable1";  // Crystal Report Name
            //dtable.
            //RD.Load(@"G:\semester 6\SE\sales\sales\CrystalReport1.rpt");
            //RD.SetDataSource(dset); //set dataset to the report viewer.
            //crystalReportViewer1.ReportSource = RD;
        //
        }
    }
}
