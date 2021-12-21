using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EsankKrushi.Data;

namespace EsankKrushi.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDuration { get; set; }
        public string ProductImage { get; set; }

        public string SaveProduct(ProductModel model)
        {
            string msg = "";
            EsankKrushiEntities db = new EsankKrushiEntities();
            var saveProduct = new tblProduct()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                ProductCategory = model.ProductCategory,
                ProductPrice = model.ProductPrice,
                ProductDuration = model.ProductDuration,
                ProductImage = model.ProductImage,
            };

            db.tblProducts.Add(saveProduct);
            db.SaveChanges();
            return msg;
        }
    }
}

   