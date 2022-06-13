using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        
        public double Price { get; set; }
        public string CarType { get; set; }
        public int CarDoor { get; set; }
        public int Seats { get; set; }
        public int LuggageSuit { get; set; }
        public int LuggageBaggage { get; set; }
        public bool Transmission { get; set; }
        public bool Airconditioning { get; set; }
        public int CarAge { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
