namespace WebApplication.Migrations
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.Context.WebApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication.Context.WebApplicationContext context)
        {
            var pessoa = new Pessoa()
            {
                Id = new Guid("2C125B4B-8EB5-4A2B-94B5-F8D6AFE4ACAB"),
                Nome = "Teste 1"
            };

            var telefones = new List<Telefone>()
            {
                new Telefone() {Id = new Guid("65F7AC77-EC6E-4FDE-8FBB-BBF79D2861FB"), Contato="11111111", PessoaId = pessoa.Id },
                new Telefone() {Id = new Guid("0214E4B0-6550-404E-B35C-BA0A0F7077AC"), Contato="22222222", PessoaId = pessoa.Id },
                new Telefone() {Id = new Guid("732264C1-B70E-4646-A708-2E4DA1B05F1F"), Contato="33333333", PessoaId = pessoa.Id }
            };

            pessoa.Telefones = telefones;

            context.Pessoas.AddOrUpdate(pessoa);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
