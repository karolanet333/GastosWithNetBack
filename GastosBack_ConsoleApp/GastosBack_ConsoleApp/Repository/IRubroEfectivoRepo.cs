
using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public interface IRubroEfectivoRepo
    {
        void Add(RubroEfectivo item);
        IEnumerable<RubroEfectivo> GetAll();
        RubroEfectivo Find(string rubro);
        IEnumerable<RubroEfectivo> FindLike(string rubro);
        RubroEfectivo GetById(int id);
        void Remove(int id);
        void Update(RubroEfectivo item);
        void SaveChanges();
    }
}
