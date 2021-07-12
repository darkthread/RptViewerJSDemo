using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWeb.Reports
{
    public partial class RptViewerLoop : System.Web.UI.Page
    {
        //https://www.aspsnippets.com/Articles/Set-ReportPath-of-Local-SSRS-Report-from-Code-Behind-in-ASPNet.aspx
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
                SetReportViewer();

        }

        private void SetReportViewer()
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath =
                Server.MapPath("~/Reports/PlayerReport.rdlc");
            ReportDataSource ds = new ReportDataSource("DataSet1",
                DemoReport.SimulateTable);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(ds);
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("StDate", "2000-01-01"));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("EdDate", "2000-01-01"));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("SortBy", "PlayerId"));
        }
    }
}