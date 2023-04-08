using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Models.DTO;
using MovieStoreMVC.Repositories.Abstract;

namespace MovieStoreMVC.Repositories.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext ctx;
        public MovieService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Movie model)
        {
            try
            {
               
                ctx.Movie.Add(model);
                ctx.SaveChanges();
                foreach (var genreId in model.Genres)
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = model.Id,
                        GenreId = genreId,
                    };
                    ctx.MovieGenre.Add(movieGenre); 

                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                var data=this.GetById(id);
                if(data == null) 
                {
                    return false;
                }
                ctx.Movie.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public Movie GetById(int id)
        {
            return ctx.Movie.Find(id);
        }

        public MovieListVm List()
        {
           var list=ctx.Movie.AsQueryable();
            var data = new MovieListVm
            {
                MovieList = list
            };
            return data;

        }

        public bool Update(Movie model)
        {
            try
            {
                ctx.Movie.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
