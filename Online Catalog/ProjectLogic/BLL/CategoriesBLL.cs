using ProjectLogic.DAL;
using System.Collections.Generic;
using ProjectLogic.BLL.Entities;

namespace ProjectLogic.BLL
{
    public class CategoriesBLL
    {
        private CategoriesDAL _context;

        public CategoriesBLL(CategoriesDAL context)
        {
            _context = context;
        }

        public List<dtCategories> GetCategories()
        {
            return _context.GetCategories();
        }
        public dtCategories GetCategoriesByID(int categoryId)
        {
            return _context.GetCategoriesByID(categoryId);
        }
        public bool AddCategory(dtCategories category, string Author="")
        {
            category.Author = Author;
            return _context.AddCategories(category);
        }
        public bool UpdateCategory(dtCategories category, string Author = "")
        {
            category.Author = Author;
            return _context.UpdateCategories(category);
        }
        public bool DeleteCategory(int id)
        {
            return _context.DeleteCategories(id);
        }
    }
}
