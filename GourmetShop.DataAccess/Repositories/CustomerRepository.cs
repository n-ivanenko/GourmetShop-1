using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Authentication;

namespace GourmetShop.DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(string connectionString) : base(connectionString, "Customer")
        {
            _insert = "GourmetShopInsertCustomer";
            _getone = "GourmetShopGetCustomerById";
        }

        public Customer Login(string username, string password)
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
                    if (Convert.ToBoolean(retval.Value))
                    {
                        return this.GetById(Convert.ToInt32(retval.Value));
                    }
                    throw new AuthenticationException("Login failed");

                }
            }
        }
    }
}