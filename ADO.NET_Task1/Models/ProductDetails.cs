using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task1.Models
{
    internal class ProductDetails
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public string ProductLink  { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public override string ToString()
        {
            return Id+" "+ Quantity + " "+ ProductLink + " " + ProductId;
        }
    }
}
