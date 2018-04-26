using CoreMeetUp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeetUp.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CityDTO() { }

        public CityDTO(City city)
        {
            Id = city.Id;
            Name = city.Name;
        }

        public void Save(City target)
        {
            target.Name = Name;
        }
    }
}