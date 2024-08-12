namespace BoniyadiInvoice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _service;
        public ProductsController(IProduct Product)
        {
            _service = Product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("No product found");
                }
                _service.CreateProduct(product);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            try
            {
                if (product == null || id <= 0)
                    return BadRequest("Product not found");

                _service.UpdateProduct(product);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var entity = _service.GetProduct(id);
                    if (entity == null)
                    {
                        return NotFound();
                    }
                    _service.DeleteProduct(entity);
                    return Ok();
                }
                else
                {
                    return NotFound("Product not found in database");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var products = _service.GetAll();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(products);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var product = _service.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }
    }
}
