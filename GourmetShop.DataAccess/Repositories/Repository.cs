using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using FastMember;
using GourmetShop.DataAccess.Entities;
using Microsoft.Data.SqlClient;

namespace GourmetShop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T: ITable, new()
    {
        private readonly string _connectionString;
        public string _table { get; protected set; }
        protected string _getall;
        protected string _insert;
        protected string _update;
        protected string _delete;

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
                using (var command = new SqlCommand(_getall, connection))
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
            this.RunNonQ(entity, _insert, false);
        }

        public void Update(T entity)
        {
            this.RunNonQ(entity, _update, true);
        } 

        public void RunNonQ(T entity, String proc, bool withId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                Type type = typeof(T);
                var accessor = TypeAccessor.Create(type);
                var members = accessor.GetMembers();
                using (var comm = new SqlCommand(proc, connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (Member m in members)
                    {
                        if (m.Name != "Id" || (m.Name == "Id" && withId)) {
                            comm.Parameters.AddWithValue(m.Name, accessor[entity, m.Name]);
                        }
                    }

                    comm.ExecuteNonQuery();

                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                Type type = typeof(T);
                var accessor = TypeAccessor.Create(type);
                var members = accessor.GetMembers();
                using (var comm = new SqlCommand(_delete, connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("Id", id);

                    comm.ExecuteNonQuery();

                }
            }
        }
    }
}