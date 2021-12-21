using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Web.Mvc;
using EsankKrushi.Data;

namespace EsankKrushi.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerDOB { get; set; }
        public string FieldArea { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string AadharNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string Photo { get; set; }

        public string SaveCustomer(CustomerModel model)
        {
            string msg = "";
            EsankKrushiEntities Db = new EsankKrushiEntities();

            var CustomerSave = new tblCustomer()
            {
                //CustId = model.CustId,
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress,
                ContactNumber = model.ContactNumber,
                ContactEmail = model.ContactEmail,
            };
            Db.tblCustomers.Add(CustomerSave);
            Db.SaveChanges();
            msg = "Customer Added Successfully";
            return msg;


        }
        public List<CustomerModel> SearchCustomer(string Prefix)
        {
            try
            {
                List<CustomerModel> model = new List<CustomerModel>();
                EsankKrushiEntities db = new EsankKrushiEntities();
                DataTable dtTable = new DataTable();
                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    try
                    {
                        db.Database.Connection.Open();
                        cmd.CommandText = "usp_GetCustomerSearch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DbParameter LID = cmd.CreateParameter();
                        LID.ParameterName = "SearchString";
                        LID.Value = Prefix;
                        cmd.Parameters.Add(LID);

                        DbDataAdapter da = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dtTable);
                        db.Database.Connection.Close();

                        foreach (DataRow dr in dtTable.Rows)
                        {
                     
                            model.Add(new CustomerModel()
                            {
                                ID = Convert.ToInt32(dr["ID"].ToString()),
                                CustomerName = dr["CustomerName"].ToString(),
                                CustomerAddress = dr["CustomerAddress"].ToString(),
                                // SalePrice = (createdDate.HasValue ? createdDate.Value.ToString("MM/dd/yyyy") : ""),
                                ContactNumber = dr["ContactNumber"].ToString(),
                                ContactEmail = dr["ContactEmail"].ToString(),
                            });
                        }


                    }
                    catch
                    {
                        db.Database.Connection.Close();
                    }
                }
                db.Dispose();
                return model.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}