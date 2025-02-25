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
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Add first api for user access layer
        [HttpPost]
        [Route("registration")]
        public Response register(Users users){
            Response response = new Response();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("connstring").ToString());

            return response;
        }
    }
}