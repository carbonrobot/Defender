namespace Data
{
    using System;

    public class Policy
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Customer Customer { get; set; }
        public DateTime EnrolledDate { get; set; }
    }
}
