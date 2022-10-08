using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ODCData;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ODCApi.Controllers
{
    public class CourseController : ApiController
    {
        

        // GET api/values
        public List<string> Get()
        {

            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Courses", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                var a = JsonConvert.SerializeObject(item);
                g.Add(item["CourseID"] + " " + item["CourseName"]);
            }

            
            return g;

        }
        public List<string> Get(int id)
        {

            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Courses where CourseID="+id, con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                var a = JsonConvert.SerializeObject(item);
                g.Add(item["CourseID"] + " " + item["CourseName"]);
            }


            return g;

        }

       
    }
}