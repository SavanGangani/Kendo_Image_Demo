using mvc_exam_krishna_tamakuwala.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mvc_exam_krishna_tamakuwala.Bal
{
    public class AuthHelper : Helper
    {
        public t_usertable Login(VM_Login user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT c_userid, c_email, c_password FROM t_usertable WHERE c_email = @c_email AND c_password = @c_password;";
            cmd.Parameters.AddWithValue("@c_email", user.c_email);
            cmd.Parameters.AddWithValue("@c_password", user.c_password);
            conn.Open();
            var loggedInUser = new t_usertable();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HttpContext.Current.Session["userid"] = Convert.ToInt32(dr["c_userid"]);
                loggedInUser.c_userid = Convert.ToInt32(dr["c_userid"]);
                loggedInUser.c_email = dr["c_email"].ToString();
                loggedInUser.c_password = dr["c_password"].ToString();
            }
            dr.Close();
            conn.Close();
            return loggedInUser;
        }

        public bool Register(t_usertable user)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO t_usertable(c_username, c_gender, c_email, c_password) VALUES(@c_username, @c_gender, @c_email, @c_password);";
            cmd.Parameters.AddWithValue("@c_username", user.c_username);
            cmd.Parameters.AddWithValue("@c_email", user.c_email);
            cmd.Parameters.AddWithValue("@c_gender", user.c_gender);
            cmd.Parameters.AddWithValue("@c_password", user.c_password);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool IsEmailExists(string email)
        {
            bool isExists = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT c_userid FROM t_usertable WHERE c_email = @c_email;";
            cmd.Parameters.AddWithValue("@c_email", email);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                isExists = true;
            }
            dr.Close();
            conn.Close();
            return isExists;
        }
    }
}