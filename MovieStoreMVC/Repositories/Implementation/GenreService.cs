using MovieStoreMvc.Repositories.Abstract;
using MovieStoreMVC.Models.Domain;


namespace MovieStoreMvc.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext ctx;
        public GenreService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Genre model)
        {
            try
            {
                ctx.Genre_Table.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Genre_Table.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre GetById(int id)
        {
            return ctx.Genre_Table.Find(id);
        }

        public IQueryable<Genre> List()
        {
            var data = ctx.Genre_Table.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                ctx.Genre_Table.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}