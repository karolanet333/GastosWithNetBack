
using GastosBack_ConsoleApp.Contexts;
using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public class RubroBancoRepo : IRubroBancoRepo, IDisposable
    {
        GastosContext _context;
        public RubroBancoRepo(GastosContext context)
        {
            _context = context;
        }

        public void Add(RubroBanco item)
        {
            _context.RubrosBanco.Add(item);
        }

        public RubroBanco Find(string rubro)
        {
            return _context.RubrosBanco
                .Where(e => e.Rubro.ToLower().Equals(rubro.ToLower()))
                .SingleOrDefault();
        }

        public IEnumerable<RubroBanco> FindLike(string rubro)
        {
            return _context.RubrosBanco.Where(x => x.Rubro.ToLower()
                    .Contains(
                                rubro.ToString()) 
                             ).ToList();
        }

        public RubroBanco GetById(int id)
        {
            return _context.RubrosBanco
                .Where(e => e.Id.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<RubroBanco> GetAll()
        {
            return _context.RubrosBanco.ToList();
        }

        public void Remove(int id)
        {
            // ToDo - Integrate with EF Core
            var itemToRemove = _context.RubrosBanco.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _context.RubrosBanco.Remove(itemToRemove);
            }

        }

        public void Update(RubroBanco item)
        {
            // ToDo - Integrate with EF Core
            var itemToUpdate = _context.RubrosBanco.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Rubro = item.Rubro;
                itemToUpdate.Signo = item.Signo;
                //_context.RubrosBanco.Update(itemToUpdate);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
