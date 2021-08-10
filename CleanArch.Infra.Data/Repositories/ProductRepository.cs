using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetProducts() => await _context.Products.ToListAsync();

        public void Add(Product product)
        {  
            _context.Add(product);
            _context.SaveChanges();
        }


        public void Remove(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
