using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EsankKrushi.Data;

namespace EsankKrushi.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Productcategory { get; set; }
        public string Productname { get; set; }
        public string Unittopurchase { get; set; }
        public string Distributorname { get; set; }
        public string Distributoraddress { get; set; }
        public string Rateofpreviousorder { get; set; }

        public string SaveOrder(OrderModel model)
        {
            string msg = "";
            EsankKrushiEntities db = new EsankKrushiEntities();
            var saveOrder = new tblOrder()
            {
                Id = model.Id,
                Productcategory = model.Productcategory,
                Productname = model.Productname,
                Unittopurchase = model.Unittopurchase,
                Distributorname = model.Distributorname,
                Distributoraddress = model.Distributoraddress,
                Rateofpreviousorder = model.Rateofpreviousorder,
            };

            db.tblOrders.Add(saveOrder);
            db.SaveChanges();
            return msg;
        }
    }
}
    
