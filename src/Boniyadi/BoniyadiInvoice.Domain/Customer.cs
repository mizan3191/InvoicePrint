namespace BoniyadiInvoice.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HouseName { get; set; }
        public string HouseNumber { get; set; }
        public string Village { get; set; }
        public string Upozilla { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string OptionalPhone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}