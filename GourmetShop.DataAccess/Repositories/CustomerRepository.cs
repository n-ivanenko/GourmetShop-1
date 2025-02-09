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

        // added Customer GetAll() -Nina (02/08)
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var comm = new SqlCommand("GourmetShopGetAllCustomers", connection))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Country = reader.GetString(reader.GetOrdinal("Country")),
                            });
                        }
                    }
                }
            }

            return customers;
        }
    }
}