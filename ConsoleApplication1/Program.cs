using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaConexion = @"Data Source=DESKTOP-7KN5JV1\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True";
           
            string queryString = "select ProductID , UnitPrice,  ProductName , UnitsInStock from Products where UnitPrice > @pricePoint and UnitsInStock < @unidades order by UnitPrice asc";

            int paramvalue = 3;
            int paramUnidades = 45;
            using (SqlConnection objConexion = new SqlConnection(cadenaConexion))

            try
            {
                    SqlCommand comand = new SqlCommand(queryString, objConexion);
                    comand.Parameters.AddWithValue("@pricePoint", paramvalue);
                    comand.Parameters.AddWithValue("@unidades", paramUnidades);
                    objConexion.Open();

                    SqlDataReader lector = comand.ExecuteReader();
                    while (lector.Read ())
                    {
                        Console.WriteLine("Product ID : {0} - UnitPrice: {1} , UnitsInStock {2} " , lector [0], lector [1] , lector [3]);
                    }
                    Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                
            }
        }
    }
}
