using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class City
    {
        public int Row_Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }


        public virtual State State { get; set; }
        public virtual ICollection<Neo_Test> Neo_Test { get; set; }
    }
}