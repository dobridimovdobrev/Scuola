using Scuola.Models.Entity;

namespace Scuola.Services
{
    public class ServiceBase
    {
        protected readonly ApplicationDbContext _context;

        protected ServiceBase(ApplicationDbContext context)
        {
            _context = context;
        }

        protected async Task<bool> SaveAsync()
        {
            bool result = false;

            try
            {
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
