using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;
namespace WebApplication1.DA
{
    public class Customers_DA
    {
        private readonly string _connectString =
    @"Server=DESKTOP-0OHJKJ4\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=true;";

        public List<Customers> GetAll()
        {
            string sqlQry = @"
                           SELECT *
  FROM [dbo].[Customers] 
  WHERE customerid='ALFKI'
                            ";

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                try
                {
                    return conn.Query<Customers>(sqlQry).ToList();
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }

        public List<Customers> GetByCustomerID(string CustomerID)
        {
            string sqlQry = @"
                           SELECT *
  FROM [dbo].[Customers] 
  WHERE CustomerID=@CustomerID
                            ";

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                try
                {
                    return conn.Query<Customers>(sqlQry, new { CustomerID }).ToList();
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }


        public int InsertData(Customers value)
        {
            string sqlQry = @"
                           INSERT INTO [dbo].[Customers]
           ([CustomerID]
           ,[CompanyName]
           ,[ContactName]
           ,[ContactTitle]
           ,[Address]
           ,[City]
           ,[Region]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Fax])
     VALUES
          ( @CustomerID,
           @CompanyName, 
           @ContactName,
           @ContactTitle,
           @Address,
           @City,
           @Region, 
           @PostalCode, 
           @Country, 
           @Phone, 
           @Fax )
                            ";

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                int result;
                try
                {
                    List<object> param = new List<object>();

                    param.Add(new
                    {
                        CustomerID = value.CustomerID,
                        CompanyName = value.CompanyName,
                        ContactName = value.ContactName,
                        ContactTitle = value.ContactTitle,
                        Address = value.Address,
                        City = value.City,
                        Region = value.Region,
                        PostalCode = value.PostalCode,
                        Country = value.Country,
                        Phone = value.Phone,
                        Fax = value.Fax
                    });

                    result = conn.Execute(sqlQry, param);
                }
                catch (Exception e)
                {

                    result = -1;
                }
                return result;
            }
        }



    }
}
