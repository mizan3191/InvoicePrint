namespace BoniyadiInvoice.DataAccess
{
    public class ProductManager : BaseDataManager, IProduct
    {
        public ProductManager(BoniyadiContext model) : base(model)
        {
        }

        public bool UpdateProduct(Product Product)
        {
            return AddUpdateEntity(Product);
        }

        public int CreateProduct(Product Product)
        {
            AddUpdateEntity(Product);
            return Product.Id;
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.SingleOrDefault(c => c.Id == id);
        }

        public IList<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public bool DeleteProduct(Product Product)
        {
            _dbContext.Remove(Product);
            _dbContext.SaveChanges();
            return true;
        }
    }
}