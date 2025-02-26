using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly string _connectionString;

        public UsersController(IConfiguration configuration){   // Create dependecy Injections so those can be accessed thoughout the class
            _configuration = configuration;
            _dataAccessLayer = new DataAccessLayer();
            _connectionString = _configuration.GetConnectionString("connstring");
        }

        // Add api for user access layer
        [HttpPost("registration")]
        public Response Register(Users users){
            Response response = new Response();
            SqlConnection conn = new SqlConnection(_connectionString);
            response = _dataAccessLayer.Register(users, conn);       // call register func from dal
            return response;
        }

        [HttpPost("login")]
        public Response Login(Users users){
            Response response = new Response();
            SqlConnection conn = new SqlConnection(_connectionString);
            response = _dataAccessLayer.Login(users, conn);       // call login func from dal
            return response;
        }
    }
}