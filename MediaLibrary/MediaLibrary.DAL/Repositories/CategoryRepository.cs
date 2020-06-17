﻿using MediaLibrary.DAL.Entities;
using MediaLibrary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MediaLibrary.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection connection;

        public CategoryRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            SqlCommand cmd = new SqlCommand("sp_GetAll_Categories", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var category = new Category
                {
                    id = Convert.ToInt32(reader["id"]),
                    name = reader["name"].ToString(),
                };
                categories.Add(category);
            }
            connection.Close();

            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Insert(Category category)
        {
            var cmd = new SqlCommand("sp_Insert_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", category.name);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return (result > 0) ? category : throw new Exception();
        }

        public Category Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}