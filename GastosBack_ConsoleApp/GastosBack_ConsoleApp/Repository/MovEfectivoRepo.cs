
using GastosBack_ConsoleApp.Contexts;
using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public class MovEfectivoRepo : IMovEfectivoRepo
    {
        GastosContext _context;
        public MovEfectivoRepo(GastosContext context)
        {
            _context = context;
        }

        public void Add(MovEfectivo item)
        {
            _context.MovsEfectivo.Add(item);
        }

        public MovEfectivo Find(string description)
        {
            return _context.MovsEfectivo
                .Where(e => e.Description.ToLower().Equals(description.ToLower()))
                .SingleOrDefault();
        }

        public IEnumerable<MovEfectivo> FindLike(string description)
        {
            return _context.MovsEfectivo.Where(x => x.Description.ToLower()
                    .Contains(
                                description.ToString())
                             ).ToList();
        }

        public IEnumerable<MovEfectivo> FindBetween(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _context.MovsEfectivo
                        .Where(x => x.FechaMov >= fechaDesde && x.FechaMov < fechaHasta)
                        .ToList();
        }

        public MovEfectivo GetById(int id)
        {
            return _context.MovsEfectivo
                .Where(e => e.Id.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<MovEfectivo> GetAll()
        {
            return _context.MovsEfectivo.ToList();
        }

        public void Remove(int id)
        {
            // ToDo - Integrate with EF Core
            var itemToRemove = _context.MovsEfectivo.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _context.MovsEfectivo.Remove(itemToRemove);
            }

        }

        public void Update(MovEfectivo item)
        {
            // ToDo - Integrate with EF Core
            var itemToUpdate = _context.MovsEfectivo.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Description = item.Description;
                itemToUpdate.Signo = item.Signo;
                //_context.MovsEfectivo.Update(itemToUpdate);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
