using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoWeb.Models;
using Microsoft.Reporting.WebForms;

namespace DemoWeb.Reports
{
    public partial class DemoReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //https://blog.darkthread.net/blog/report-viewer-infinite-loop/
            //防止無窮迴圈
            if (ScriptManager1.IsInAsyncPostBack) return;

            var st = Request.Form["st"] ?? Request.QueryString["st"] ?? string.Empty;
            var ed = Request.Form["ed"] ?? Request.QueryString["ed"] ?? string.Empty;
            var s = Request.Form["s"] ?? Request.QueryString["s"] ?? string.Empty;
            var p = Request["p"] ?? "NA";
            var paramDict = (MemoryCache.Default.Get(p)) as Dictionary<string, string>;
            if (paramDict != null)
            {
                st = paramDict["st"];
                ed = paramDict["ed"];
                s = paramDict["s"];
            }
            if (string.IsNullOrEmpty(st) || string.IsNullOrEmpty(ed) || string.IsNullOrEmpty(s))
            {
                //未傳參數時顯示空白
                ReportViewer1.Visible = false;
            }
            else
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PlayerReport.rdlc");

                //此處以 DataView 模擬查詢資料庫
                DataView view = SimulateData.DataTable.DefaultView;
                //指定排序依據
                view.Sort = s;
                //指定查詢區間
                view.RowFilter = 
                    $"RegDate >= '{DateTime.Parse(st):yyyy-MM-dd}' AND RegDate <= '{DateTime.Parse(ed):yyyy-MM-dd}'";

                ReportDataSource ds = new ReportDataSource("DataSet1", view.ToTable());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(ds);
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("StDate", st));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("EdDate", ed));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("SortBy", s));
            }
        }
    }
}