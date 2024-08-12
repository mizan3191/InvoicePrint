namespace BoniyadiInvoice.DataAccess
{
    public class CustomerManager : BaseDataManager, ICustomer
    {
        public CustomerManager(BoniyadiContext model) : base(model)
        {
        }

        public bool UpdateCustomer(Customer Customer)
        {
            return AddUpdateEntity(Customer);
        }

        public int CreateCustomer(Customer Customer)
        {
            AddUpdateEntity(Customer);
            return Customer.Id;
        }

        public Customer GetCustomer(int id)
        {
            return _dbContext.Customers.SingleOrDefault(c => c.Id == id);
        }

        public IList<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public bool DeleteCustomer(Customer Customer)
        {
            _dbContext.Remove(Customer);
            _dbContext.SaveChanges();
            return true;
        }
    }
}