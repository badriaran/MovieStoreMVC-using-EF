﻿using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Models.DTO;

namespace MovieStoreMVC.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();

    }
}
