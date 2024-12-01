using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task1.Models
{
    internal class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
