using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public string Adress {  get; set; }
        public List<Order> orders { get; set; } = new List<Order>();
    }
}
