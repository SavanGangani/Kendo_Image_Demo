using mvc_exam_krishna_tamakuwala.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mvc_exam_krishna_tamakuwala.Bal
{
    public class StudentHelper : Helper
    {
        public List<t_studenttable> GetAll()
        {
            List<t_studenttable> studentList = new List<t_studenttable>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT c_id, c_image, c_name FROM t_studenttable;";
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var student = new t_studenttable();
                student.c_id = Convert.ToInt32(dr["c_id"]);
                student.c_image = dr["c_image"].ToString();
                student.c_name = dr["c_name"].ToString();
                studentList.Add(student);
            }
            dr.Close();
            conn.Close();
            return studentList;
        }

        public t_studenttable GetOne(int id)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT c_id, c_image, c_name FROM t_studenttable WHERE c_id = @c_id;";
            cmd.Parameters.AddWithValue("@c_id", id);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            var student = new t_studenttable();
            if (dr.Read())
            {
                student.c_id = Convert.ToInt32(dr["c_id"]);
                student.c_image = dr["c_image"].ToString();
                student.c_name = dr["c_name"].ToString();
            }
            dr.Close();
            conn.Close();
            return student;
        }

        public bool Add(t_studenttable student)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO t_studenttable(c_image, c_name) VALUES(@c_image, @c_name);";
            cmd.Parameters.AddWithValue("@c_image", student.c_image);
            cmd.Parameters.AddWithValue("@c_name", student.c_name);
            conn.Open();
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool Update(t_studenttable student)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE t_studenttable SET c_image = @c_image, c_name = @c_name WHERE c_id = @c_id;";
            cmd.Parameters.AddWithValue("@c_id", student.c_id);
            cmd.Parameters.AddWithValue("@c_image", student.c_image);
            cmd.Parameters.AddWithValue("@c_name", student.c_name);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM t_studenttable WHERE c_id = @c_id;";
            cmd.Parameters.AddWithValue("@c_id", id);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }
    }
}