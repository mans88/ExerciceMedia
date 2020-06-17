using MediaLibrary.DAL.Entities;
using MediaLibrary.DAL.Enumerations;
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
            SqlCommand cmd = new SqlCommand("sp_Delete_Media", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@id", id);
            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return result > 0;
        }

        public ICollection<Media> GetAll()
        {
            List<Media> medias = new List<Media>();

            SqlCommand cmd = new SqlCommand("sp_GetAll_Medias", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var media = new Media
                {
                    id = Convert.ToInt32(reader["id"]),
                    name = reader["name"].ToString(),
                    url = reader["url"].ToString(),
                    path = reader["path"].ToString(),
                    type = (MediaType)Enum.Parse(typeof(MediaType), reader["type"].ToString()),
                    done = Convert.ToBoolean(reader["done"]),
                };
                medias.Add(media);
            }
            connection.Close();

            return medias;
        }

        public Media GetById(int id)
        {
            Media media = new Media();

            SqlCommand cmd = new SqlCommand("sp_GetById_Category", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                media.id = Convert.ToInt32(reader["id"]);
                media.name = reader["name"].ToString();
                media.url = reader["url"].ToString();
                media.path = reader["path"].ToString();
                media.type = (MediaType)Enum.Parse(typeof(MediaType), reader["type"].ToString());
                media.done = Convert.ToBoolean(reader["done"]);
            }
            connection.Close();

            return media;
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