using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GourmetShop.DataAccess.Repositories
{
    public class CustomerRepository : Repository<Product>
    {
        public CustomerRepository(string connectionString) : base(connectionString, "Customer")
        {
            _insert = "GourmetShopInsertProduct";
        }

        public bool Login(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var comm = new SqlCommand("GourmetShopLoginCustomer", connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter retval = new SqlParameter();
                    retval.Direction = ParameterDirection.ReturnValue;

                    comm.Parameters.AddWithValue("pLogin", username);
                    comm.Parameters.AddWithValue("pPassword", password);
                    comm.Parameters.Add(retval);
                    comm.ExecuteScalar();

                    return Convert.ToBoolean(retval.Value);

                }
            }
        }
    }
}