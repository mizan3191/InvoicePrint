namespace BoniyadiInvoice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _service;
        public CustomersController(ICustomer Customer)
        {
            _service = Customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("No Customer found");
                }
                _service.CreateCustomer(customer);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Customer customer)
        {
            try
            {
                if (customer == null || id <= 0)
                    return BadRequest("customer not found");

                _service.UpdateCustomer(customer);
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
                    var entity = _service.GetCustomer(id);
                    if (entity == null)
                    {
                        return NotFound();
                    }
                    _service.DeleteCustomer(entity);
                    return Ok();
                }
                else
                {
                    return NotFound("Customer not found in database");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            try
            {
                var customers = _service.GetAll();

                if (customers == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customers);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            try
            {
                var customer = _service.GetCustomer(id);

                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
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
