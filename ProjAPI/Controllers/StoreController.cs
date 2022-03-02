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
        /// <summary>
        /// Will send back a response of all customers currently in the database
        /// </summary>
        public IActionResult GetAllCustomers()
        {
            try
            {
                Log.Information("Received all customers as a response.");
                return Ok(_customerBL.GetAllCustomers());
            }
            catch (System.Exception)
            {
                Log.Warning("Could not fetch customers");
                throw;
            }
            
        }

        // GET: api/Store/customer/email  ?email=   ---search by email
        [HttpGet("customer/email")]
        /// <summary>
        /// searches database for a customer by their email
        /// </summary>
        /// <param name="email">takes in a user email</param>
        /// <returns>Returns a customer by their email</returns>
        public IActionResult GetCustomerByEmail([FromQuery] string email)
        {
            try
            {
                Log.Information("Searching for customer by email");
            return Ok(_customerBL.SearchCustomerByEmail(email));
            }
            catch (System.Exception)
            {
                Log.Warning("Was not able to search for customer by email");
                throw;
            }
        }

        //GET: api/Store/customer/email/orders  --- get all orders associated with a customer
        [HttpGet("customer/email/orders")]
        /// <summary>
        /// Searches for all orders belonging to a specific customer
        /// </summary>
        /// <param name="email">Takes in a user email to search by. Must match exactly.</param>
        /// <returns>Returns orders by a specific customer</returns>
        public IActionResult GetCustomerOrders([FromQuery] string email)
        {
            try
            {
                Log.Information("Using customer email to search for orders");
            return Ok(_storeBL.GetOrdersByCustomerEmail(email));
            }
            catch (System.Exception)
            {
                Log.Warning("Was not able to retreive orders by customer email.");
                throw;
            }
        }

         //GET: api/Store/customer/email/orders/{sortby}  --- get all orders associated with a customer and sort by some parameter
        [HttpGet("customer/email/orders/{sortby}")]
        /// <summary>
        /// Searches for and sorts orders by a specific customer and a sortby parameter
        /// </summary>
        /// <param name="email">Takes in a user email. Must be specific, case-sensitive</param>
        /// <param name="sortby">One of 4 keywords to sortby - new/old/highprice/lowprice and sorts accordingly</param>
        /// <returns>Orders sorted either by order id which increment so are by time created or by totalprice</returns>
        public IActionResult GetCustomerOrdersAndSort([FromQuery] string email, string sortby)
        {
            try
            {
                 if (sortby == "new")
            {
                Log.Information("Retrieving orders by customer newest to oldest");
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderByDescending(p => p.OrderID));
            }
            else if (sortby == "old")
            {
                Log.Information("Retrieving orders by customer oldest to newest");
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderBy(p => p.OrderID));
            }            
            else if (sortby == "highprice")
            {
                Log.Information("Retrieving orders by customer most expensive to least");
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderByDescending(p => p.TotalPrice));
            }
            else if (sortby == "lowprice")
            {
                Log.Information("Retrieving orders by customer least expensive to most");
            return Ok(_storeBL.GetOrdersByCustomerEmail(email).OrderBy(p => p.TotalPrice));
            }
            else {
                Log.Warning("Wrong keyword was used");
                return NotFound("Please input keywords: 'new' | 'old' | 'highprice' | 'lowprice'");
            }
            }
            catch (System.Exception)
            {
                Log.Warning("Was not able to receive orders.");
                throw;
            }
           
        }

        //GET: api/Store/address/orders/{sortby}  --- get all orders associated with a store and sort it by some criteria
        [HttpGet("address/orders/{sortby}")]
        /// <summary>
        /// Searches for and sorts orders by a specific address(store location) and a sortby parameter
        /// </summary>
        /// <param name="address">Takes in a store location address. Must be specific, case-sensitive</param>
        /// <param name="sortby">One of 4 keywords to sortby - new/old/highprice/lowprice and sorts accordingly</param>
        /// <returns>Orders sorted either by order id which increment so are by time created or by totalprice</returns>
        public IActionResult GetStoreOrders([FromQuery] string address, string sortby)
        {
            try
            {
                 if (sortby == "new")
            {
                Log.Information("Retrieving orders by store newest to oldest");
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderByDescending(p => p.OrderID));
            }
            else if (sortby == "old")
            {
                Log.Information("Retrieving orders by store oldest to newest");
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderBy(p => p.OrderID));
            }
            else if (sortby == "highprice")
            {
                Log.Information("Retrieving orders by store most expensive to least");
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderByDescending(p => p.TotalPrice));
            }
            else if (sortby == "lowprice")
            {
                Log.Information("Retrieving orders by store least expensive to most");
            return Ok(_storeBL.GetOrdersByStoreAddress(address).OrderBy(p => p.TotalPrice));
            }
            else {
                Log.Warning("Wrong keyword was used");
                return NotFound("Please input keywords: 'new' | 'old' | 'highprice' | 'lowprice'");
            }
            }
            catch (System.Exception)
            {
                Log.Warning("Was not able to receive orders.");
                throw;
            }
        }

        //GET: api/Store/customer/orderdetail  --- get order details by order id
        [HttpGet("customer/email/orderdetail")]
        /// <summary>
        /// Provides order details given a specific order id
        /// </summary>
        /// <param name="orderID">the order id belonging to a specific past order</param>
        /// <returns>order details about an order</returns>
        public IActionResult GetCustomerOrderDetails([FromQuery] int orderID)
        {
            try
            {
            Log.Information("Getting order details by an order id");
            return Ok(_storeBL.GetProductsInOrder(orderID));
            }
            catch
            {
                Log.Warning("Was not able to receive order details by id");
                throw;
            }
        }

       

        //GET: api/Store/address/inventory  --- view all inventory at a location
        [HttpGet("address/inventory")]
        /// <summary>
        /// Shows a view of all inventory at a specific location
        /// </summary>
        /// <param name="address">Takes in a store location address. Must be specific, case-sensitive</param>
        /// <param name="userEmail">Takes in a case-sensitive email. Used to validate if user is authorized to perform this transaction</param>
        /// <param name="userPassword">Takes in a case-sensitive password. Used to validate if user is authorized to perform this transaction</param>
        /// <returns></returns>
        public IActionResult GetInventoryAtAStore([FromQuery] string address, string userEmail, string userPassword)
        {
            Log.Information("Checking if user has admin privileges");
            if(_storeBL.IsAdmin(userEmail, userPassword)){
                try
            {
            Log.Information("Viewing inventory at a store");
            return Ok(_storeBL.GetProductsByStore(address));
            }
            catch (System.Exception)
            {
                    Log.Warning("Unable to view inventory at a store");
                throw;
            }
            }
                else
                {
                    Log.Warning("User is receiving status code 401 and is unauthorized for this");
                    return StatusCode(401);
                    }
        }
            
            
            
            
        



        
        // POST: api/Store/customer/add   --- adds a new customer from a json body
        [HttpPost("customer/add")]
        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="p_customer">takes ina  full customer object</param>
        /// <returns>Returns status that it was added to db</returns>
        public IActionResult PostCustomer([FromBody] Customer p_customer)
        {
            try
            {
                Log.Information("Added a customer");
            return Created("Successfully added", _customerBL.AddCustomer(p_customer));
            }
            catch (System.Exception)
            {
                Log.Warning("Was unable to add customer");
                throw;
            }
        }

        // POST: api/Store/customer/order/make   --- adds a new order from a json body
        [HttpPost("customer/order/make")]
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="p_order">takes ina  full order object</param>
        /// <returns>Returns status that it was added to db</returns>
        public IActionResult PostOrder([FromBody] Orders p_order)
        {
            try
            {
                Log.Information("Added an order");
            return Created("Successfully added", _storeBL.AddOrder(p_order));
            }
            catch (System.Exception)
            {
                Log.Warning("Was unable to add order");
                throw;
            }
        }

        

        // PUT: api/Store/address/updateinv
        [HttpPut("address/updateinv")]
        /// <summary>
        /// Will update a stores inventory after validating that a user has the admin level of authorization.
        /// </summary>
        /// <param name="productID">Takes in an integer value. This is the product ID</param>
        /// <param name="amountToAdd">Takes in an integer value. This is the amount you wish to add to a product inventory</param>
        /// <param name="address">Takes in a store location address. Must be specific, case-sensitive</param>
        /// <param name="userEmail">Takes in a case-sensitive email. Used to validate if user is authorized to perform this transaction</param>
        /// <param name="userPassword">Takes in a case-sensitive password. Used to validate if user is authorized to perform this transaction</param>
        /// <returns></returns>
        public IActionResult UpdateInventoryAtAStore([FromQuery] int productID, int amountToAdd, string address, string userEmail, string userPassword)
        {
            Log.Information("Checking if user has admin privileges");
           if(_storeBL.IsAdmin(userEmail, userPassword)){
           try
           {
               Log.Information("Updating store inventory");
               List<StoreFront> listOfStores = _storeBL.SearchStoreByAddress(address);
               int storeID = listOfStores[0].StoreID;
               _storeBL.UpdateInventory(productID, amountToAdd, storeID);
               return StatusCode(200);
            }
           catch (System.Exception)
           {
               Log.Warning("Was unable to update inventory");
               return BadRequest();
            }
           }
        else {
                    Log.Warning("User is receiving status code 401 and is unauthorized to do this");
                   return StatusCode(401);
               }
           
        }

        
    }
}
