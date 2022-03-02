using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjBL;
using ProjDL;
using ProjModel;

namespace ProjAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly ICustomerBL _customerBL;
        private readonly StoreBL _storeBL;

        public StoreController(ICustomerBL p_customerBL, IStoreBL p_storeBL)
        {
            _customerBL = p_customerBL;
            _storeBL = (StoreBL)p_storeBL;

        }

        // GET: api/Store/customer/getall ---retrieves all customers in db but not their orders
        [HttpGet("customer/getall")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerBL.GetAllCustomers());
        }

        // GET: api/Store/customer/email  ?email=   ---search by email
        [HttpGet("customer/email")]
        public IActionResult GetCustomerByEmail([FromQuery] string email)
        {
            return Ok(_customerBL.SearchCustomerByEmail(email));
        }

        //GET: api/Store/customer/email/orders  --- get all orders associated with a customer
        [HttpGet("customer/email/orders")]
        public IActionResult GetCustomerOrders([FromQuery] string email)
        {
            return Ok(_storeBL.GetOrdersByCustomerEmail(email));
        }

         //GET: api/Store/customer/email/orders/{sortby}  --- get all orders associated with a customer and sort by some parameter
        [HttpGet("customer/email/orders/{sortby}")]
        public IActionResult GetCustomerOrdersAndSort([FromQuery] string email, string sortby)
        {
            try
            {
                 if (sortby == "new")
            {
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderByDescending(p => p.OrderID));
            }
            else if (sortby == "old")
            {
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderBy(p => p.OrderID));
            }
            else if (sortby == "highprice")
            {
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderByDescending(p => p.TotalPrice));
            }
            else if (sortby == "lowprice")
            {
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderBy(p => p.TotalPrice));
            }
            else {
                return NotFound("Please input keywords: 'new' | 'old' | 'highprice' | 'lowprice'");
            }
            }
            catch (System.Exception)
            {
                
                throw;
            }
           
        }

        //GET: api/Store/address/orders/{sortby}  --- get all orders associated with a store and sort it by some criteria
        [HttpGet("address/orders/{sortby}")]
        public IActionResult GetStoreOrders([FromQuery] string address, string sortby)
        {
            try
            {
                 if (sortby == "new")
            {
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderByDescending(p => p.OrderID));
            }
            else if (sortby == "old")
            {
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderBy(p => p.OrderID));
            }
            else if (sortby == "highprice")
            {
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderByDescending(p => p.TotalPrice));
            }
            else if (sortby == "lowprice")
            {
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderBy(p => p.TotalPrice));
            }
            else {
                return NotFound("Please input keywords: 'new' | 'old' | 'highprice' | 'lowprice'");
            }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        //GET: api/Store/customer/orderdetail  --- get order details by order id
        [HttpGet("customer/email/orderdetail")]
        public IActionResult GetCustomerOrderDetails([FromQuery] int orderID)
        {
            return Ok(_storeBL.GetProductsInOrder(orderID));
        }

        //GET: api/Store/customer/orderdetail  --- get order details for a customer or 
        // [HttpPost("customer/createorder")]
        // public IActionResult CreateOrder(Orders p_order)
        // {
        //     _storeBL.InitializeOrder(p_order);            
        //     return Ok(_storeBL.MakeOrder(LineItems p_lineItems, int quantity, int p_storeID));
        // }

        //GET: api/Store/address/inventory  --- view all inventory at a location
        [HttpGet("address/inventory")]
        public IActionResult GetInventoryAtAStore([FromQuery] string address, string userEmail, string userPassword)
        {
            if(_storeBL.IsAdmin(userEmail, userPassword)){
                try
            {
                
            return Ok(_storeBL.GetProductsByStore(address));
            }
            catch (System.Exception)
            {
                throw;
            }
            }
                else
                {return StatusCode(401);}
        }
            
            
            
            
        



        
        // POST: api/Store/customer/add   --- adds a new customer from a json body
        [HttpPost("customer/add")]
        public IActionResult Post([FromBody] Customer p_customer)
        {
            return Created("Successfully added", _customerBL.AddCustomer(p_customer));
        }

        // PUT: api/Store/address/updateinv
        [HttpPut("address/updateinv")]
        public IActionResult UpdateInventoryAtAStore([FromQuery] int productID, int amountToAdd, string address, string userEmail, string userPassword)
        {
           if(_storeBL.IsAdmin(userEmail, userPassword)){
           try
           {
               
               List<StoreFront> listOfStores = _storeBL.SearchStoreByAddress(address);
               int storeID = listOfStores[0].StoreID;
               _storeBL.UpdateInventory(productID, amountToAdd, storeID);
               return StatusCode(200);
               
               
               
           }
           catch (System.Exception)
           {
               
               return BadRequest();
            }
           }
        else {
                   return StatusCode(401);
               }
           
        }

        
    }
}
