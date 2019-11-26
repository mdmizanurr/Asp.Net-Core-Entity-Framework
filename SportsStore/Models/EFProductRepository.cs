﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private SportDbContext context;

        public EFProductRepository(SportDbContext db)
        {
            context = db;
        }

        public IQueryable<Product> Products => context.Products;


    }
}
