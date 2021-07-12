using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DemoWeb.Models
{
    public class SimulateData
    {
        public static DataTable DataTable = null;
        static SimulateData()
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

            DataTable = t;
        }
    }
}