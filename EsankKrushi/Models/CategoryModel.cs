using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EsankKrushi.Data;

namespace EsankKrushi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }

        public string SaveCategory(CategoryModel model)
        {
            string msg = "";
            EsankKrushiEntities db = new EsankKrushiEntities();
            var saveCategory = new tblCategory()
            {
                ProductCategory = model.ProductCategory,
            };

            db.tblCategories.Add(saveCategory);
            db.SaveChanges();
            return msg;
        }
    }
}
   