using GastosBack_ConsoleApp.Hubs;
using GastosBack_ConsoleApp.Models;
using GastosBack_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using static System.Net.WebRequestMethods;

namespace GastosBack_ConsoleApp.Controllers
{
    public class RubrosBancoController: ApiController
    {
        /*public IHttpActionResult Get()
        {
            return Ok("Hello, web API");
        }*/

        private IRubroBancoRepo _repo;

        public RubrosBancoController(IRubroBancoRepo _rubroBancoRepo)
        {
            _repo = _rubroBancoRepo;
        }

        [HttpGet]
        public IEnumerable<RubroBanco> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        public RubroBanco GetById(int Id)
        {
            var item = _repo.GetById(Id);
            return item;
        }

        //public RubroBanco Find(string Rubro)
        //{
        //    var item = _repo.Find(Rubro);
        //    return item;
        //}

        //public IEnumerable<RubroBanco> FindLike(string rubro)
        //{
        //    return _repo.FindLike(rubro);
        //}

        /*[HttpPost]
        public IHttpActionResult Add(string title)
        {
            //Creates a Movie based on the Title
            return Ok();
        }*/

        [HttpPost]
        public IHttpActionResult Create([FromBody] RubroBanco item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            _repo.SaveChanges();

            //obtener el Id para devolverlo al cliente
            var rubroBanco = _repo.Find(item.Rubro);

            RubrosBancoHub.Changed();

            return CreatedAtRoute("DefaultApi", new { Id = item.Id }, rubroBanco);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] RubroBanco item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var obj = _repo.GetById(item.Id);
            if (!Exists(item.Id))
            {
                return NotFound();
            }
            _repo.Update(item);
            _repo.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            if (!Exists(Id))
            {
                return NotFound();
            }
            _repo.Remove(Id);
            _repo.SaveChanges();
            return Ok();
        }

        private bool Exists(int id)
        {
            bool rpta = true;
            var obj = _repo.GetById(id);
            if (obj == null)
            {
                rpta = false;
            }
            return rpta;
        }

        private new void Dispose()
        {
            if (_repo != null)
            {
                _repo.Dispose();
            }
            base.Dispose();
        }
    }
}