
using GastosBack_ConsoleApp.Contexts;
using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public class RubroEfectivoRepo : IRubroEfectivoRepo 
    {
        GastosContext _context;
        public RubroEfectivoRepo(GastosContext context)
        {
            _context = context;
        }

        public void Add(RubroEfectivo item)
        {
            _context.RubrosEfectivo.Add(item);
        }

        public RubroEfectivo Find(string rubro)
        {
            return _context.RubrosEfectivo
                .Where(e => e.Rubro.ToLower().Equals(rubro.ToLower()))
                .SingleOrDefault();
        }

        public IEnumerable<RubroEfectivo> FindLike(string rubro)
        {
            return _context.RubrosEfectivo.Where(x => x.Rubro.ToLower()
                    .Contains(
                                rubro.ToString())
                             ).ToList();
        }

        public RubroEfectivo GetById(int id)
        {
            return _context.RubrosEfectivo
                .Where(e => e.Id.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<RubroEfectivo> GetAll()
        {
            return _context.RubrosEfectivo.ToList();
        }

        public void Remove(int id)
        {
            // ToDo - Integrate with EF Core
            var itemToRemove = _context.RubrosEfectivo.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _context.RubrosEfectivo.Remove(itemToRemove);
            }
                
        }

        public void Update(RubroEfectivo item)
        {
            // ToDo - Integrate with EF Core
            var itemToUpdate = _context.RubrosEfectivo.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Rubro = item.Rubro;
                itemToUpdate.Signo = item.Signo;
                
                //_context.RubrosEfectivo.Update(itemToUpdate);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
