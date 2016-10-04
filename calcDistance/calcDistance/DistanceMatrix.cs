using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace calcDistance
{
    class DistanceMatrix
    {
        private int getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            //string from = origin.Text;
            //string to = destination.Text;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key=AIzaSyBRsV_JdR7AIF0BBzrb3Hi-TemGvC1ThNk";
          
            string requesturl = url;
            Console.WriteLine(requesturl);
            //string requesturl = @"http://maps.googleapis.com/maps/api/directions/json?origin=" + from + "&alternatives=false&units=imperial&destination=" + to + "&sensor=false";
            string content = fileGetContents(requesturl);
            JObject o = JObject.Parse(content); //this is a bug, can't parse Parsing JSON Object using JObject.Parse
            try
            {
                distance = (int)o.SelectToken("rows[0].elements[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
            return distance;
            //ResultingDistance.Text = distance;
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }

        public void calc()
        {
            String strA = "Ha+Noi";
            String strB = "TPHCM";
            string kq = GetDistance(strA, strB);
            Console.WriteLine(kq);
        }








        //==========================================================


        public string GetDistance(string origin, string destination)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&sensor=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables["element"].Rows[0]["status"].ToString() == "OK")
                {
                    //  lblDuration.Text = ds.Tables["duration"].Rows[0]["text"].ToString();
                    return ds.Tables["distance"].Rows[0]["text"].ToString();
                }
              
            }
            return "unable to connect to server ";

        }
    }
}
