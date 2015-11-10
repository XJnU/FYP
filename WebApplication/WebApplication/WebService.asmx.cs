using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private string ANo = "1AOop0tbIr6qMDSqqANO8A==";
        private string UUID = "64422844-f582-42bd-88cb-597770aa3916";

        public class TaxiAvail{
            public string lat;
            public string lon;
            public DateTime dt;
            public string area;
        }

        /*
         public List<IncidentEntry> GetIncidentFromNimbusLTA(string AccountKey, string UniqueUserID)
    {

        System.Net.WebRequest wr=
          HttpWebRequest.Create(
            "https://api.projectnimbus.org/ltaodataservice.svc/IncidentSet?Latitude=1.3&Longitude=103.85&Distance=2000");
        wr.Headers.Add("AccountKey",AccountKey wr.Headers.Add("UniqueUserID",UniqueUserID wr.Method = "GET";
        WebResponse res = wr.GetResponse();
        string resStr
         = new System.IO.StreamReader(res.GetResponseStream()).ReadToEnd();

        XNamespace atomNS
          = "http://www.w3.org/2005/Atom";
        XNamespace dNS
          = "http://schemas.microsoft.com/ado/2007/08/dataservices";
        XNamespace mNS
          = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";

        List<IncidentEntry> results
          = (from item in XElement.Parse(resStr).Descendants(atomNS + "entry")
            let incident = item.Element(atomNS + "content").Element(mNS +"properties")
                select new IncidentEntry() {
                IncidentID incident.Element(dNS +"IncidentID").Value,
                Message = incident.Element(dNS +"Message").Value,
                Lat = incident.Element(dNS + "Latitude").Value,
                Lon = incident.Element(dNS + "Longitude").Value
            }).ToList();

        return results;
    }
         * 
         * recursivelyCallMultipleServices(true);
 
// In this case, I use is_new_call variable as a flag indicating the new set of web-services
// And the current variable and the total variable to determine the next call
function recursivelyCallMultipleServices(is_new_call, current, total){
     if(is_new_call){
          // initializing variables for doing recursion
          is_new_call = false;
          current = 0;
          total = web_services.length;
 
          // calling the first web-service, specify callback function back into this function again (we are doing recursion remember?) 
          // and attaching the current variable and the total variable with the callback's results
          recursivelyCallMultipleServices(web_services[current], dojo.partial(recursivelyCallMultipleServices, is_new_call, current, total));
     }
     else{
          // processing each result… here you might save the result to some variables…
          // ...
 
          // moving on 
          current++;
 
          // keeping track of the progress
          if(current == total){ // all the services have been called?
               // end of recursion
               finishRecursion();
          }
          else{
               // calling the next web-service
               recursivelyCallMultipleServices(web_services[current], dojo.partial(recursivelyCallMultipleServices, is_new_call, current, total));
          }
     }
}
 
function finishRecursion(){
     // doing whatever you want with all the results…
     // …
}
         */

        [WebMethod]
        public string getTaxiAvailability(string AccountKey, string UniqueUserID)
        {
            List<TaxiAvail> taxiList = new List<TaxiAvail>();

          System.Net.WebRequest wr= HttpWebRequest.Create("http://datamall2.mytransport.sg/ltaodataservice/TaxiAvailability");
          wr.Headers.Add("AccountKey",ANo);
          wr.Headers.Add("UniqueUserID",UniqueUserID);
          wr.Method = "GET";
          WebResponse res = wr.GetResponse();
          string resStr
           = new System.IO.StreamReader(res.GetResponseStream()).ReadToEnd();


          return resStr;
        }
    }
}
