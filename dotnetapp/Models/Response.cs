using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models {
     public class Response {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
                
        public List<Users> listUsers{ get; set; } // Requiered in admin pannel, It will return List of Users
        public Users user { get; set; } // This will return particular user either on email bases or ID base
        public List<Medicines> listMedicines { get; set; } // This will return list of medicines
        public Medicines medicines { get; set; } // This will only return particular medicine
        public List<Cart> listCart { get; set; } // This will return all the items in the cart
        public List<Orders> listOrders { get; set; } // This will only return particular Orders
        public Orders orders { get; set; } // This will return all the orders
        public List<OrderItems> listOrderItems { get; set; } // This will return OrderItems
        public OrderItems orderItems { get; set; } // This will return all OrderItem
    }
}