using Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeetUp.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }

        public GroupDTO() { }

        public GroupDTO(Group group)
        {
            Id = group.Id;
            Name = group.Name;
            Category = group.Category;
            City = group.City;
        }

        public void Save(Group target)
        {
            target.Name = Name;
            target.Category = Category;
            target.City = City;
        }
    }
}