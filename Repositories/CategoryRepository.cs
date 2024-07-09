using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObjects;

namespace Repositories
{
    public class CategoryRepository: ICatergoryRepository
    {
        public List<Category> GetCategories() => CategoryDAO.Instance.GetCategories();   

    }
}
