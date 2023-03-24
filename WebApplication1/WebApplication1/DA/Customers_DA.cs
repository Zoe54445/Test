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

            using (SqlConnection conn =  new SqlConnection(_connectString))
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
                    return conn.Query<Customers>(sqlQry,new { CustomerID }).ToList();
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }



    }
}
