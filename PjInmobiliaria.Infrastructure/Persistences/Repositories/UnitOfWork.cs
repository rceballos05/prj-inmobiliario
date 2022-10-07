using PjInmobiliaria.Infrastructure.Persistences.Contexts;
using PjInmobiliaria.Infrastructure.Persistences.Interfaces;

namespace PjInmobiliaria.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly PjInmobiliarioContext context;
        public IClienteRepository Cliente {get; private set;}
        public UnitOfWork(PjInmobiliarioContext _context)
        {
            context = _context;
            Cliente = new ClienteRepository(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
