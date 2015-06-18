using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = getJobsContent("https://gist.githubusercontent.com/WillemLabu/34cfb50187ec334c48ee/raw/84f2ebf1c2343a23792d725ef3da4a9c61f10857/jobs.json");
        var o = JObject.Parse(json);
        
        #region Data Table

        DataTable dtJobList = new DataTable();
        dtJobList.Columns.Add("Client", typeof(string));
        dtJobList.Columns.Add("jobNumber", typeof(int));
        dtJobList.Columns.Add("jobName", typeof(string));
        dtJobList.Columns.Add("Due", typeof(DateTime));
        dtJobList.Columns.Add("Status", typeof(string));
        DataRow drow = null;
        #endregion
        int i = 0;
        StringBuilder html = new StringBuilder();
        foreach (var x in o["jobs"])
        {
            drow = dtJobList.NewRow();
            dtJobList.Rows.Add(drow);
            dtJobList.Rows[i]["Client"] = (string)(x["client"]);
            dtJobList.Rows[i]["jobNumber"] = (int)(x["job-number"]);
            dtJobList.Rows[i]["jobName"] = (string)(x["job-name"]);
            dtJobList.Rows[i]["Due"] = (DateTime)(x["due"]);
            dtJobList.Rows[i]["Status"] = (string)(x["status"]);
            i++;
        }

        foreach (DataRow row in dtJobList.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dtJobList.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        this.placeHolder.Controls.Add(new Literal { Text = html.ToString() });
    }

    public class Job
    {
        public string client { get; set; }
        public int jobnumber { get; set; }
        public string jobname { get; set; }
        public string due { get; set; }
        public string status { get; set; }
    }

    public class Jobs
    {
        public List<Job> jobs { get; set; }
    }
    public string getJobsContent(string url)
    {
        string output = "";
        try
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            output = reader.ReadToEnd();
            response.Close();
        }
        catch (Exception)
        {
            throw;
        }
        return output;
    }
}

