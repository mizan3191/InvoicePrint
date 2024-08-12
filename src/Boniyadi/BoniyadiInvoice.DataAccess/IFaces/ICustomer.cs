namespace BoniyadiInvoice.DataAccess
{
    public interface ICustomer
    {
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        int CreateCustomer(Customer customer);
        Customer GetCustomer(int id);
        IList<Customer> GetAll();
    }
}
