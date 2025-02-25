using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace dotnetapp.Models
{
    // This is for connecting the Database through ADO .NET
    public class DataAccessLayer
    {
        Response response = new Response();
        public Response register(Users users, SqlConnection conn){
            SqlCommand cmd  = new SqlCommand("sp_register", conn);  // sp_register is name of the procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirsName",users.FirstName);
            cmd.Parameters.AddWithValue("@LastName",users.LastName);
            cmd.Parameters.AddWithValue("@Password",users.Password);
            cmd.Parameters.AddWithValue("@Email",users.Email);
            cmd.Parameters.AddWithValue("@Phone",users.Phone);
            cmd.Parameters.AddWithValue("@Fund",0); // default fund is 0 that is assigned by the Admin
            cmd.Parameters.AddWithValue("@Type","Users");
            cmd.Parameters.AddWithValue("@Status","Pending"); // bcz only admin can change the status

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if(i>0){
                response.StatusCode = 200;
                response.StatusMessage = "User registerd successfully";
            }else{
                response.StatusCode = 100;  // it indicates the server needs more information before it can process the request
                response.StatusMessage = "User registration failed";
            }
            return response;
        }
    }
}


