using MediaLibrary.DAL.Entities;
using System.Collections.Generic;

namespace MediaLibrary.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Category Insert(Category category);

        Category GetById(int id);

        ICollection<Category> GetAll();

        bool Delete(int id);

        Category Update(Category category);
    }
}