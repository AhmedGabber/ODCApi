using Newtonsoft.Json;
using ODCData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ODCApi.Controllers
{
    public class StudentsController : ApiController
    {


        public List<string> Get()
        {
            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            foreach (DataRow item in dt.Rows)

            {
                var a = JsonConvert.SerializeObject(item);
                g.Add(item["StudentID"] + " " + item["StudentName"]);
            }


            return g;
        }


        public List<string> Get(int id)
        {
            //SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            //List<string> g = new List<string>();
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students where StudentID=" + id, con);
            //DataTable dt = new DataTable();

            //da.Fill(dt);
            //foreach (DataRow item in dt.Rows)

            //{
            //    var a = JsonConvert.SerializeObject(dt.Rows);

            //    g.Add(item["studentID"] + " " + item["StudentName"]);

            //}

            //return g;
            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("select t.StudentName, k.SkillName,tk.SkillQuiz from Skills k  join StudentSkills tk on k.Skill_ID = tk.Skill_ID join Students t on tk.StudentID = t.StudentID where t.StudentID =   " + id, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)

            {
                var a = JsonConvert.SerializeObject(dt.Rows);

                g.Add(" " + item["SkillName"]);

            }

            return g;
        }

        public List<Student> GetProfile(int id)
        {
            ODCDataEntities db = new ODCDataEntities();

            List<Student> e = db.Students.Where(x => x.StudentID == id).ToList();

            return e;


        }
        public List<string> StudentSkills(int id)
        {
            SqlConnection con = new SqlConnection(@"server=.;database=ODCData;integrated Security=true;");
            List<string> g = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("select t.StudentName, k.SkillName,tk.SkillQuiz from Skills k  join StudentSkills tk on k.Skill_ID = tk.Skill_ID join Students t on tk.StudentID = t.StudentID where t.StudentID = 1  " + id, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)

            {
                var a = JsonConvert.SerializeObject(dt.Rows);

                g.Add( " " + item["SkillName"]);

            }

            return g;
        }
    }
}
