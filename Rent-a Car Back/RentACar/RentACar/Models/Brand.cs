using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
