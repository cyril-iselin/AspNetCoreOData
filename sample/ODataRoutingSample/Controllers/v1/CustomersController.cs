//-----------------------------------------------------------------------------
// <copyright file="CustomersController.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved.
//      See License.txt in the project root for license information.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using ODataRoutingSample.Models;

namespace ODataRoutingSample.Controllers.v1
{
    [ODataRouteComponent("v1")]
    public class CustomersController : ControllerBase
    {
        private MyDataContext _context = new MyDataContext();
        public CustomersController()
        {
          
                if (_context.Customers.Count() == 0)
                {
                    IList<Customer> customers = GetCustomers();

                    foreach (var customer in customers)
                    {
                        _context.Customers.Add(customer);
                    }

                    _context.SaveChanges();
                }
            
        }

        [HttpGet]
        [EnableQuery(PageSize = 250)]
        public IActionResult Get()
        {


            return Ok(_context.Customers);

        }

        [HttpGet]
        [EnableQuery]
        public Customer Get(int key)
        {
            
            return new Customer
            {
                Id = key,
                Name = "Name + " + key
            };
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            return Ok();
        }

        [HttpPost]
        public string RateByName(int key, [FromODataBody] string name, [FromODataBody] int age)
        {
            return key + name + ": " + age;
        }

        [HttpPost]
        [EnableQuery]
        public IActionResult BoundAction(int key, ODataActionParameters parameters)
        {
            return Ok($"BoundAction of Customers with key {key} : {System.Text.Json.JsonSerializer.Serialize(parameters)}");
        }

        private static IList<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Jonier",
                    FavoriteColor = Color.Red,
                   
                },
                new Customer
                {
                    Id = 2,
                    Name = "Sam",
                    FavoriteColor = Color.Blue,
                  
                },
                new Customer
                {
                    Id = 3,
                    Name = "Peter",
                    FavoriteColor = Color.Green,
                  
                }
            };
        }
    }
}
