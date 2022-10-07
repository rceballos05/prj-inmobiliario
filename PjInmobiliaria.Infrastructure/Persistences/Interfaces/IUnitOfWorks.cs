namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWorks : IDisposable
    {
        // aquí se declaran todas las interfaces
        IClienteRepository Cliente { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
