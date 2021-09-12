using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly ApplicationDbContext Context;
        public PersonRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Person> Create(Person person)
        {
            var _obj = await Context.Persons.AddAsync(person);
            Context.SaveChanges();
            return _obj.Entity;
        }

        public void Delete(Person person)
        {
            Context.Remove(person);
            Context.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return Context.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return Context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Person person)
        {
            Context.Persons.Update(person);
            Context.SaveChanges();
        }
    }
}
