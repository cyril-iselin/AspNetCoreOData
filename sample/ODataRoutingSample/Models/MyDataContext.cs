//-----------------------------------------------------------------------------
// <copyright file="MyDataContext.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved.
//      See License.txt in the project root for license information.
// </copyright>
//------------------------------------------------------------------------------

using System.Data.Entity;

namespace ODataRoutingSample.Models
{
    public class MyDataContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

      
    }
}
