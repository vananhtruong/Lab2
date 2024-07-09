using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessObjects;
using DateAccessLayer;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private readonly MyStoreContext dbcontext;
        private static readonly object instanceLock = new object();



        //instance singleton
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();

                    }
                    return instance;
                }
            }
        }
        public List<Category> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                using var context = new MyStoreContext();
                list = context.Categories.ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
