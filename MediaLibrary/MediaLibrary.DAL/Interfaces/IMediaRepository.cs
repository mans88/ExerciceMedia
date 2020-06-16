using MediaLibrary.DAL.Entities;
using System.Collections.Generic;

namespace MediaLibrary.DAL.Interfaces
{
    internal interface IMediaRepository
    {
        Media Insert(Media entity);

        Media GetById(int id);

        ICollection<Media> GetAll();

        bool Delete(int id);

        Media Update(Media entity);
    }
}