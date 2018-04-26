using CoreMeetUp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeetUp.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonDTO() { }

        public PersonDTO(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public void Save(Person target)
        {
            target.FirstName = FirstName;
            target.LastName = LastName;
        }
    }
}