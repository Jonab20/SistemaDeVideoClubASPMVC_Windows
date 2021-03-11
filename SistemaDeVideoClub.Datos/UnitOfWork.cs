using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
