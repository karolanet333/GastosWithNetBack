using GastosBack_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosBack_ConsoleApp.Repository
{
    public interface IRubroBancoRepo: IDisposable
    {
        void Add(RubroBanco item);
        IEnumerable<RubroBanco> GetAll();
        RubroBanco Find(string rubro);
        IEnumerable<RubroBanco> FindLike(string rubro);
        RubroBanco GetById(int id);
        void Remove(int id);
        void Update(RubroBanco item);
        void SaveChanges();
    }
}
