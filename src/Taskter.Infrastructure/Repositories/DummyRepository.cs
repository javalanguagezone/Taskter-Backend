using System.Collections.Generic;
using System.Linq;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class DummyRepository : IDummyRepository
    {
        private readonly TaskterDbContext _context;

        public DummyRepository(TaskterDbContext context)
        {
            _context = context;
        }

        public void AddDummy(Dummy dummy)
        {
            _context.Dummies.Add(dummy);
            _context.SaveChanges();
        }

        public IEnumerable<Dummy> GetAll()
        {
            return _context.Dummies.ToList();
        }

        public Dummy GetById(int id)
        {
            return _context.Dummies.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDummy(Dummy dummy)
        {
            _context.SaveChanges();
        }
    }
}