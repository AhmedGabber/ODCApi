using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ODCApi.Controllers
{
    public class SkillsController : ApiController
    {
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
                g.Add(item["Skill_ID"] + " " + item["SkillName"]);
            }

            
            return g;
        }

        public List<string> Get(int id)
        {
            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Skills where Skill_ID=" + id, con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            foreach (DataRow item in dt.Rows)

            {
                var a = JsonConvert.SerializeObject(dt.Rows);

                g.Add(item["Skill_ID"] + " " + item["SkillName"]);

            }

            return g;
        }

    }
}
