using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        
        public List<Users> listUsers{ get; set; } //Requiered in admin pannel, It ll return List of Users
        public Users user { get; set; } // This ll return particular user either on email bases or ID base
        public List<Medicines> listMedicines{ get; set; } //This ll return list of medicines
        public Medicines medicines{ get; set; } //This will only return particular medicine
        public List<Cart> listCart { get; set; } //This ll return all the items in the cart
        public List<Orders> listOrders { get; set; }
        public Orders orders{ get; set; }
        public List<OrderItems> listOrdersItems { get; set; }
        public OrderItem orderItem{ get; set; }
    }
}