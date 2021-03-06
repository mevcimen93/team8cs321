using EZmenities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace EZmenities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataTable GetData()
        {
            DataTable dtTemp = new DataTable("DataTable");
            //Add columns to it 
            dtTemp.Columns.Add("Ammenity");
            dtTemp.Columns.Add("Time");
            dtTemp.Columns.Add("AptNum");
            dtTemp.Columns.Add("Chair");
            dtTemp.Columns.Add("Date");
            if (System.IO.File.Exists("EZmenitiesData.xml"))
                dtTemp.ReadXml("EZmenitiesData.xml");
            // Clean the dates that are expired 
            Boolean found = false;
            for (int i = dtTemp.Rows.Count - 1; i > -1; i--)
            {
                if (dtTemp.Rows[i]["Date"].ToString() != DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"))
                {
                    dtTemp.Rows.RemoveAt(i);
                    found = true;
                }
            }
            if (found)
                dtTemp.WriteXml("EZmenitiesData.xml");
            return dtTemp;
        }

        private DataTable GetPartnerData()
        {
            DataTable dtPartTemp = new DataTable("PartnerDataTable");
            //Add columns to it 
            dtPartTemp.Columns.Add("Sport");
            dtPartTemp.Columns.Add("Name");
            dtPartTemp.Columns.Add("Info");
            dtPartTemp.Columns.Add("PreferedTime");
            dtPartTemp.Columns.Add("Date");
            if (System.IO.File.Exists("EZmenitiesPartnerData.xml"))
                dtPartTemp.ReadXml("EZmenitiesPartnerData.xml");
            // Clean the dates that are expired 
            Boolean found = false;
            for (int i = dtPartTemp.Rows.Count - 1; i > -1; i--)
            {
                if (dtPartTemp.Rows[i]["Date"].ToString() != DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"))
                {
                    dtPartTemp.Rows.RemoveAt(i);
                    found = true;
                }
            }
            if (found)
                dtPartTemp.WriteXml("EZmenitiesPartnerData.xml");
            return dtPartTemp;
        }

        private void SaveData(DataTable dtTemp)
        {
            dtTemp.WriteXml("EZmenitiesData.xml");
        }

        private void SaveDataPartner(DataTable dtPartTemp)
        {
            dtPartTemp.WriteXml("EZmenitiesPartnerData.xml");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pool(string time)
        {
            DataTable dt = GetData();
            var data = new List<List<string>>();
            int[] PoolChairs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int chair in PoolChairs)
            {
                var row = new List<string>();
                row.Add(chair.ToString());
                bool found = false;
                foreach (DataRow drTmp in dt.Rows)
                {
                    if (drTmp["Ammenity"].ToString() == "Pool" && drTmp["Chair"].ToString() == chair.ToString() && drTmp["Time"].ToString() == time)
                    {
                        row.Add("Reserved");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    row.Add("Available");
                data.Add(row);
            }
            return View(data);
        }

        public IActionResult BasketBall()
        {
            DataTable dt = GetData();
            var data = new List<List<string>>();
            string[] TimeSlots = { "10AM - 11AM", "11AM - 12PM", "1PM - 2PM", "2PM - 3PM", "3PM - 4PM", "4PM - 5PM" };
            for (int i = 0; i < TimeSlots.Length; i++)
            {
                var row = new List<string>();
                row.Add(TimeSlots[i]);
                bool found = false;
                foreach (DataRow drTmp in dt.Rows)
                {
                    if (drTmp["Ammenity"].ToString() == "Basketball" && drTmp["Time"].ToString() == TimeSlots[i])
                    {
                        row.Add("Reserved");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    row.Add("Available");
                data.Add(row);
            }
            return View(data);
        }

        public IActionResult Tennis()
        {
            DataTable dt = GetData();
            var data = new List<List<string>>();
            string[] TimeSlots = { "10AM - 11AM", "11AM - 12PM", "1PM - 2PM", "2PM - 3PM", "3PM - 4PM", "4PM - 5PM" };
            for (int i = 0; i < TimeSlots.Length; i++)
            {
                var row = new List<string>();
                row.Add(TimeSlots[i]);
                bool found = false;
                foreach (DataRow drTmp in dt.Rows)
                {
                    if (drTmp["Ammenity"].ToString() == "Tennis" && drTmp["Time"].ToString() == TimeSlots[i])
                    {
                        row.Add("Reserved");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    row.Add("Available");
                data.Add(row);
            }
            return View(data);
        }

        public IActionResult BBQ(string time)
        {
            DataTable dt = GetData();
            var data = new List<List<string>>();
            int[] Grills = { 1, 2, 3, 4 };
            foreach (int grill in Grills)
            {
                var row = new List<string>();
                row.Add(grill.ToString());
                bool found = false;
                foreach (DataRow drTmp in dt.Rows)
                {
                    if (drTmp["Ammenity"].ToString() == "Grill" && drTmp["Chair"].ToString() == grill.ToString() && drTmp["Time"].ToString() == time)
                    {
                        row.Add("Reserved");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    row.Add("Available");
                data.Add(row);
            }
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PartnerFinder(string sportName)
        {
            DataTable dt = GetPartnerData();
            var data = new List<List<string>>();
            foreach (DataRow drTmp in dt.Rows)
            {
                if (drTmp["Sport"].ToString() == sportName)
                {
                    var row = new List<string>();
                    row.Add(drTmp["Name"].ToString());
                    row.Add(drTmp["Info"].ToString());
                    row.Add(drTmp["PreferedTime"].ToString());
                    data.Add(row);
                }
            }
            return View(data);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PartnerFinderRequest(string sportName, string name, string contactInfo, string preferedTime)
        {
            try
            {
                DataTable dtp = GetPartnerData();
                DataRow dr = dtp.NewRow();
                dr["Sport"] = sportName;
                dr["Name"] = name;
                dr["Info"] = contactInfo;
                dr["PreferedTime"] = preferedTime;
                dr["Date"] = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                dtp.Rows.Add(dr);
                SaveDataPartner(dtp);

                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PoolRequest(int chairNumber, string time, bool isReserve, string aptlNumber)
        {
            try
            {
                DataTable dt = GetData();
                if (isReserve)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ammenity"] = "Pool";
                    dr["Time"] = time;
                    dr["AptNum"] = aptlNumber;
                    dr["Chair"] = chairNumber.ToString();
                    dr["Date"] = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                    dt.Rows.Add(dr);
                    SaveData(dt);
                }
                else
                {
                    var RowsFound = dt.AsEnumerable().Where(r => r.Field<string>("Time") == time.ToString() && r.Field<string>("Ammenity") == "Pool" && r.Field<string>("AptNum") == aptlNumber && r.Field<string>("Chair") == chairNumber.ToString());
                    if (RowsFound.Count() > 0)
                    {
                        DataRow rowFound = RowsFound.ElementAt<DataRow>(0);
                        rowFound.Delete();
                        SaveData(dt);
                    }
                }
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult TennisRequest(string time, bool isReserve, string aptlNumber)
        {
            try
            {
                DataTable dt = GetData();
                if (isReserve)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ammenity"] = "Tennis";
                    dr["AptNum"] = aptlNumber;
                    dr["Time"] = time;
                    dr["Date"] = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                    dt.Rows.Add(dr);
                    SaveData(dt);
                }
                else
                {
                    var RowsFound = dt.AsEnumerable().Where(r => r.Field<string>("Time") == time && r.Field<string>("Ammenity") == "Tennis" && r.Field<string>("AptNum") == aptlNumber);
                    if (RowsFound.Count() > 0)
                    {
                        DataRow rowFound = RowsFound.ElementAt<DataRow>(0);
                        rowFound.Delete();
                        SaveData(dt);
                    }
                }
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult BasketballRequest(string time, bool isReserve, string aptlNumber)
        {
            try
            {
                DataTable dt = GetData();
                if (isReserve)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ammenity"] = "Basketball";
                    dr["AptNum"] = aptlNumber;
                    dr["Time"] = time;
                    dr["Date"] = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                    dt.Rows.Add(dr);
                    SaveData(dt);
                }
                else
                {
                    var RowsFound = dt.AsEnumerable().Where(r => r.Field<string>("Time") == time && r.Field<string>("Ammenity") == "Basketball" && r.Field<string>("AptNum") == aptlNumber);
                    if (RowsFound.Count() > 0)
                    {
                        DataRow rowFound = RowsFound.ElementAt<DataRow>(0);
                        rowFound.Delete();
                        SaveData(dt);
                    }
                }
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult GrillRequest(int grillNumber, string time, bool isReserve, string aptlNumber)
        {
            try
            {
                DataTable dt = GetData();
                if (isReserve)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ammenity"] = "Grill";
                    dr["Time"] = time;
                    dr["AptNum"] = aptlNumber;
                    dr["Chair"] = grillNumber.ToString();
                    dr["Date"] = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                    dt.Rows.Add(dr);
                    SaveData(dt);
                }
                else
                {
                    var RowsFound = dt.AsEnumerable().Where(r => r.Field<string>("Time") == time && r.Field<string>("Ammenity") == "Grill" && r.Field<string>("AptNum") == aptlNumber && r.Field<string>("Chair") == grillNumber.ToString());
                    if (RowsFound.Count() > 0)
                    {
                        DataRow rowFound = RowsFound.ElementAt<DataRow>(0);
                        rowFound.Delete();
                        SaveData(dt);
                    }
                }
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }
    }
}
