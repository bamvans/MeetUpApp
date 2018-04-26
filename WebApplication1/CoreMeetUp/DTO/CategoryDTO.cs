using CoreMeetUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeetUp.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDTO() { }

        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }

        public void Save(Category target)
        {
            target.Name = Name;
            target.Description = Description;
        }
    }
}