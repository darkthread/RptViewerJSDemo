using DemoWeb.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Redirect("~/SPA/report.html");
        }

        public ActionResult RptViewerInMvc()
        {
            var rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath =
                Server.MapPath("~/Reports/PlayerReport.rdlc");
            ReportDataSource ds = new ReportDataSource("DataSet1",
                SimulateData.DataTable);
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(ds);
            rv.LocalReport.SetParameters(new ReportParameter("StDate", "2000-01-01"));
            rv.LocalReport.SetParameters(new ReportParameter("EdDate", "2000-01-01"));
            rv.LocalReport.SetParameters(new ReportParameter("SortBy", "PlayerId"));
            ViewBag.ReportViewer = rv;
            return View();
        }
    }
}