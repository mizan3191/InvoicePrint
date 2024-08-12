namespace BoniyadiInvoice.DataAccess
{
    public interface IProduct
    {
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        int CreateProduct(Product product);
        Product GetProduct(int id);
        IList<Product> GetAll();
    }
}
