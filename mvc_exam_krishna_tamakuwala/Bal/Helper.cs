using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;

namespace mvc_exam_krishna_tamakuwala.Bal
{
    public class Helper
    {
        protected NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
    }
}