using System;
using System.Collections.Generic;
using System.Linq;
using FastMember;
using GourmetShop.DataAccess.Entities;
using Microsoft.Data.SqlClient;

namespace GourmetShop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T: new()
    {
        private readonly string _connectionString;
        private readonly string _table;

        public Repository(string connectionString, string table)
        {
            _connectionString = connectionString;
            _table = table;
        }

        public T ReaderToT(SqlDataReader reader)
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.IsDBNull(i))
                {
                    string fieldname = reader.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldname, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldname] = reader.GetValue(i);
                    }
                }
            }
            return t;
        }

        public IEnumerable<T> GetAll()
        {
            var results = new List<T>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(string.Format("GourmetShopGetAll{0}", _table), connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         results.Add(ReaderToT(reader));
                        }
                    }
                }
            }
            return results;

        }

        public T GetById(int id)
        {
            // Add SQL logic for fetching a record by ID
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                Type type = typeof(T);
                var accessor = TypeAccessor.Create(type);
                var members = accessor.GetMembers();
                using (var comm = new SqlCommand(string.Format("GourmetShopInsert{0}", _table), connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (Member m in members)
                    {
                        if (m.Name != "Id") {
                            comm.Parameters.AddWithValue(m.Name, accessor[entity, m.Name]);
                        }
                    }

                    comm.ExecuteNonQuery();

                }
            }
        }

        public void Update(T entity)
        {
            // Add SQL logic for updating a record
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            // Add SQL logic for deleting a record
            throw new NotImplementedException();
        }
    }
}