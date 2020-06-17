using MediaLibrary.DAL.Entities;
using MediaLibrary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MediaLibrary.DAL.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly SqlConnection connection;

        public MediaRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Media> GetAll()
        {
            throw new NotImplementedException();
        }

        public Media GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Media Insert(Media entity)
        {
            var cmd = new SqlCommand("sp_Insert_Media", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", entity.name);
            cmd.Parameters.AddWithValue("@path", entity.path);
            cmd.Parameters.AddWithValue("@type", entity.type);
            cmd.Parameters.AddWithValue("@url", entity.url);
            cmd.Parameters.AddWithValue("@done", entity.done);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return (result > 0) ? entity : throw new Exception();
        }

        public Media Update(Media entity)
        {
            throw new NotImplementedException();
        }
    }
}