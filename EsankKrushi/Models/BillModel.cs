using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EsankKrushi.Data;

namespace EsankKrushi.Models
{
    public class BillModel
    { 
            public int ID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string Date { get; set; }
            public string ProductName { get; set; }
            public string Price { get; set; }
            public string NoofUnit { get; set; }
        public string SaveBill(BillModel model)
        {
            string msg = "";
            EsankKrushiEntities Db = new EsankKrushiEntities();
            {
                var BillData = new Bill()
                {
                    CustomerName = model.CustomerName,
                    CustomerAddress = model.CustomerAddress,
                    Date = model.Date,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    NoofUnit = model.NoofUnit,

                };
                Db.Bills.Add(BillData);
                Db.SaveChanges();
                return msg;
            }
        }


 public List<BillModel>GetBillList(string CustomerName)
{
    EsankKrushiEntities db = new EsankKrushiEntities();
    List<BillModel> str = new List<BillModel>();
    var BillList = db.Bills.Where(p => p.CustomerName == CustomerName).ToList();
    if (BillList != null)
    {
        foreach (var reg in BillList)
        {
            str.Add(new BillModel()
            {
                ID = reg.ID,
                CustomerName = reg.CustomerName,
                CustomerAddress = reg.CustomerAddress,
                Date = reg.Date,
                ProductName = reg.ProductName,
                Price = reg.Price,
                NoofUnit = reg.NoofUnit,
            });
        }
    }
    return str;
}


//public string deleteBill(int Id)
//{
//    string Message = "";
//    EsankKrushiEntities Db = new EsankKrushiEntities();
//    var deleteRecord = Db.Bills.Where(p => p.ID == Id).FirstOrDefault();
//    if (deleteRecord != null)
//    {
//        Db.Bills.Remove(deleteRecord);
//    };
//    Db.SaveChanges();
//    Message = "Record Deleted Successfully";
//    return Message;
//}

//public BillModel EditData(int Id)
//{
//    string msg = "";
//    BillModel model = new BillModel();
//    EsankKrushiEntities Db = new EsankKrushiEntities();
//    var editData = Db.Bills.Where(p => p.ID == Id).FirstOrDefault();
//    if (editData != null)
//    {
//        model.ID = editData.ID;
//        model.CustomerName = editData.CustomerName;
//        model.CustomerAddress = editData.CustomerAddress;
//        model.Date = editData.Date;
//        model.ProductName = editData.ProductName;
//        model.Price = editData.Price;
//        model.NoofUnit = editData.NoofUnit;
//    }

//    msg = "Record Deleted Successfully";
//    return model;
//          }
      }
}


