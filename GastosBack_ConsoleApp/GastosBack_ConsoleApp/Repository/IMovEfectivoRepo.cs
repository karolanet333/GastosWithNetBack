
using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public interface IMovEfectivoRepo
    {
        void Add(MovEfectivo item);
        IEnumerable<MovEfectivo> GetAll();
        MovEfectivo Find(string description);
        IEnumerable<MovEfectivo> FindLike(string description);
        IEnumerable<MovEfectivo> FindBetween(DateTime fechaDesde, DateTime fechaHasta);
        MovEfectivo GetById(int id);
        void Remove(int id);
        void Update(MovEfectivo item);
        void SaveChanges();
    }
}
