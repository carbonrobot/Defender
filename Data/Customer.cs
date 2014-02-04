namespace Data
{
    using System.Collections.Generic;

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Policy> Policies{get; set;}
    }
}
