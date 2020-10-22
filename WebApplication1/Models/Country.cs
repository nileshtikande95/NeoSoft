using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Country
    {
        public int Row_Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Neo_Test> Neo_Test { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}