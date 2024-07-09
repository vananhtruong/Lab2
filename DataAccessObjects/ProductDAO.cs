using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private readonly MyStoreContext dbcontext;
        private static readonly object instanceLock = new object();



        //instance singleton
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();

                    }
                    return instance;
                }
            }
        }



        public List<Product> GetProducts()
        {
            var listproduct = new List<Product>();
            try
            {
                using var db = new MyStoreContext();

                listproduct = db.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listproduct;
        }
        //public static void SaveProduct(Product product)
        //{

        //    try
        //    {
        //        using var db = new MyStoreContext();
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public void SaveProduct(Product product)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                // Log the detailed error
                var errorMessage = GetFullErrorMessage(dbEx);
                throw new Exception($"An error occurred while saving the entity changes: {errorMessage}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while saving the product.", ex);
            }
        }

        private string GetFullErrorMessage(DbUpdateException exception)
        {
            var errorMessages = exception.Entries
                .SelectMany(e => e.Entity.GetType().GetProperties(), (e, p) => new { Entry = e, Property = p })
                .Select(x => $"{x.Property.Name} : {x.Entry.Property(x.Property.Name).CurrentValue}")
                .ToList();

            errorMessages.Add(exception.Message);

            var innerException = exception.InnerException;
            while (innerException != null)
            {
                errorMessages.Add(innerException.Message);
                innerException = innerException.InnerException;
            }

            return string.Join(" | ", errorMessages);
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Update(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteProduct(Product product)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                using var db = new MyStoreContext();
                product = db.Products.SingleOrDefault(c => c.ProductId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
    }
}