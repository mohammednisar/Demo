using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication1
{
    

    public class Dataservice
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        public DataTable GetAllStates()
        {
            cmd = new SqlCommand("GetAllStates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void InsertNewState(Pservice P)
        {
            cmd = new SqlCommand("InsertNewState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sname", P.StateName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateState(Pservice P)
        {
            cmd = new SqlCommand("UpdateState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SID", P.StateID);
            cmd.Parameters.AddWithValue("@Sname", P.StateName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteState(Pservice P)
        {
            cmd = new SqlCommand("DeleteState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SID", P.StateID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}