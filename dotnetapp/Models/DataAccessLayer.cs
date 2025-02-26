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
        public Response Register(Users users, SqlConnection conn){
            Response response = new Response();
            SqlCommand command  = new SqlCommand("sp_register", conn);  // sp_register is name of the procedure
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FirsName",users.FirstName);
            command.Parameters.AddWithValue("@LastName",users.LastName);
            command.Parameters.AddWithValue("@Password",users.Password);
            command.Parameters.AddWithValue("@Email",users.Email);
            command.Parameters.AddWithValue("@Phone",users.Phone);
            command.Parameters.AddWithValue("@Fund",0); // default fund is 0 that is assigned by the Admin
            command.Parameters.AddWithValue("@Type","Users");
            command.Parameters.AddWithValue("@Status","Pending"); // bcz only admin can change the status

            conn.Open();
            int i = command.ExecuteNonQuery();
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

        public Response Login(Users users, SqlConnection conn){
            SqlDataAdapter adapter = new SqlDataAdapter("sp_login", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Email",users.Email);
            adapter.SelectCommand.Parameters.AddWithValue("@Password",users.Password);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Response response = new Response();
            if(dataTable.Rows.Count>0){
                response.StatusCode = 200;
                response.StatusMessage = "User is valid";
            }else{
                response.StatusCode = 100;
                response.StatusMessage = "User is invalid";
            }
            return response;
        }
    }
}