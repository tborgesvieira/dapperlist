using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Context;
using Dapper;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private WebApplicationContext _db = new WebApplicationContext();

        public ActionResult Index()
        {
            var pessoa = _db.Pessoas.ToList().First();

            return View(pessoa);
        }

        public ActionResult Dapper()
        {
            var _cn = _db.Database.Connection;

            var sql = @"select t1.*, t2.* from Pessoas t1
                            left join Telefones t2
                            on t1.Id = t2.PessoaId";

            var retorno = new Dictionary<Guid, Pessoa>();

            _cn.Query<Pessoa, Telefone, Pessoa>(sql,
            (p, t) => {
                Pessoa pessoa;
                if (!retorno.TryGetValue(p.Id, out pessoa))
                {
                    pessoa = p;
                    pessoa.Telefones = new List<Telefone>();

                    retorno.Add(pessoa.Id, pessoa);
                }

                pessoa.Telefones.Add(t);

                return pessoa;
            }, splitOn: "Id,Id");

            return View(retorno.Values.First());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}