using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Home : System.Web.UI.Page
    {
        private string AccountKey = "1AOop0tbIr6qMDSqqANO8A==";
        private string UniqueUserID = "70cb7e51-a5c2-482e-b2f0-814383062cda";
        private string url = "http://datamall2.mytransport.sg/ltaodataservice/TaxiAvailability";
        public string json, jsonData;
        public JArray arr = new JArray();

        public class TAXI_AVA
        {
            public string Lat { get; set; }
            public string Long { get; set; }
        }

        public class TAXI_RESULT
        {
            public JObject metadata { get; set; }
            public JArray values { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool result = true, is_new_call = true;
            int counter = 0;
            JObject obj = new JObject();

            using (var w = new WebClient())
            {
                w.Headers.Add("AccountKey", AccountKey);
                w.Headers.Add("UniqueUserID", UniqueUserID);
                w.Headers.Add("accept", "application/json");
                try
                {
                    while (result)
                    {
                        if (is_new_call)
                        {
                            json = w.DownloadString(url);
                            //json = json.TrimEnd(new char[] { '\r', '\n' });
                            obj = JObject.Parse(json);
                            //jsonData = new JavaScriptSerializer().Serialize(obj);
                            arr = (JArray)obj["value"];
                            Label1.Text = "LatLong: " + arr.First().ToString() + "\n\n" + json;
                            is_new_call = false;
                        }
                        else
                        {
                            counter += 50;
                            json = w.DownloadString(url + "?$skip=" + counter);
                            obj = JObject.Parse(json);
                            //json = json.TrimEnd(new char[] { '\r', '\n' });
                            JArray items = (JArray)obj["value"];
                            for(int i = 0; i<items.Count(); i++)
                                arr.Add(items[i]);
                            if (json.Length < 2500)
                            {
                                result = false;

                                /* Script manager for heatmap */
                                //ScriptManager.RegisterStartupScript(this, GetType(), "addHeatMap", "getPoints(" + arr + ");", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "initialize", "initMap();", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "addHeatMap", "getCluster(" + arr + ");", true);
                                /* End */

                                Label2.Text = arr.Count().ToString();
                            }
                           
                        }
                    }
                }

                catch (Exception ex)
                {
                    Label1.Text = ex.ToString();
                }
            }
        }
    }
}