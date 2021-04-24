namespace SistemaDeVideoClub.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;

        public UnitOfWork(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Save()
        {
            _DbContext.SaveChanges();
        }
    }
}
