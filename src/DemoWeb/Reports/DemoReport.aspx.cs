﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace DemoWeb.Reports
{
    public partial class DemoReport : System.Web.UI.Page
    {
        static DataTable SimulateTable = null;
        static DemoReport()
        {
            var t = new DataTable();
            t.Columns.Add(new DataColumn("PlayerId", typeof(string)));
            t.Columns.Add(new DataColumn("Name", typeof(string)));
            t.Columns.Add(new DataColumn("RegDate", typeof(DateTime)));
            t.Columns.Add(new DataColumn("Score", typeof(int)));
            var rnd = new Random(9527);

            int i = 1;
            typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                        .Select(c => (Color)c.GetValue(null, null))
                        .ToList()
                        .ForEach(c =>
                        {
                            t.Rows.Add(
                                $"P{i++:000}",
                                c, 
                                new DateTime(1990, 1, 1).AddDays(rnd.Next(10000)), 
                                rnd.Next(32767));
                        });

            SimulateTable = t;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ScriptManager1.IsInAsyncPostBack) return;

            var st = Request["st"] ?? string.Empty;
            var ed = Request["ed"] ?? string.Empty;
            var s = Request["s"] ?? string.Empty;
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
                ReportViewer1.Visible = false;
            }
            else
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PlayerReport.rdlc");

                //此處理 DataView 模擬查詢資料庫
                DataView view = SimulateTable.DefaultView;
                view.Sort = s;
                view.RowFilter = $"RegDate >= '{DateTime.Parse(st):yyyy-MM-dd}' AND RegDate <= '{DateTime.Parse(ed):yyyy-MM-dd}'";

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