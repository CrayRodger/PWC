using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWC_Task_3._0.Models;
using DotNet.Highcharts;

namespace PWC_Task_3._0.Controllers
{
    public class ChartSampleController : Controller
    {


        // GET: ChartSample
        public ActionResult Index()
        {
            //create a collection data
            var transactionCounts = new List<TransactionCount> {
                new TransactionCount() {MonthName="Junuary", Count = 30},
                new TransactionCount() {MonthName="February", Count = 40},
                new TransactionCount() {MonthName="March", Count = 4},
                new TransactionCount() {MonthName="April", Count = 35},
                new TransactionCount() {MonthName="April", Count = 7},
            };
            //modify data type to make it of array type
            var xDataMonths = transactionCounts.Select(i => i.MonthName).ToArray();
            var yDataCounts = transactionCounts.Select(i => new object[] { i.Count}).ToArray();

            //instantiate an object of the Highcharts type
            var chart = new Highcharts("chart")

            //define  the type of chart
            .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Line })
            .SetTitle(new DotNet.Highcharts.Options.Title { Text = "Incoming transaction per hour" })
            .SetSubtitle(new DotNet.Highcharts.Options.Subtitle { Text = "Accounting" })
            .SetXAxis(new DotNet.Highcharts.Options.XAxis { Categories = xDataMonths })
            .SetYAxis(new DotNet.Highcharts.Options.YAxis
            {
                Title = new DotNet.Highcharts.Options.YAxisTitle { Text = "Number of Transactions" }
            })
            .SetTooltip(new DotNet.Highcharts.Options.Tooltip
            {
                Enabled = true,
                Formatter = @"function() {return '<b>' + this.series.name + '</b><br/>' + this.x + ': '  + this.y;}"

            })
            .SetPlotOptions(new DotNet.Highcharts.Options.PlotOptions
            {
                Line = new DotNet.Highcharts.Options.PlotOptionsLine
                {
                    DataLabels = new DotNet.Highcharts.Options.PlotOptionsLineDataLabels
                    {
                        Enabled = true
                    },
                    EnableMouseTracking = false
                }

            })
            .SetSeries(new[]
            {
                new DotNet.Highcharts.Options.Series {Name = "Hour", Data = new DotNet.Highcharts.Helpers.Data(yDataCounts)},

            });


            return View(chart);
        }
    }
}