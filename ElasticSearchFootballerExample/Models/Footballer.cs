using System;

namespace ElasticSearchFootballerExample.Models
{
    public class Footballer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
    }
}
