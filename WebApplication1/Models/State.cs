using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class State
    {
        public int Row_Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }


        public virtual ICollection<City> Citie { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Neo_Test> Neo_Test { get; set; }
    }
}