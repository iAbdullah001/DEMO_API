using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class PersonService
    {
        private readonly IRepository<Person> repository;
        public PersonService(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        // GET All Person Details   
        public IEnumerable<Person> GetAllPersons()
        {
            return repository.GetAll().ToList();
        }

        //Get Person by Id
        public Person GetPersonById(int id)
        {
            return repository.GetById(id);
        }

        // Add Person  
        public async Task<Person> AddPerson(Person Person)
        {
            return await repository.Create(Person);
        }

        // Delete Person   
        public bool DeletePerson(int id)
        {
            var person = repository.GetById(id);
            if (person != null)
            {
                try
                {
                    repository.Delete(person);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // Update Person Details  
        public bool UpdatePerson(Person person)
        {
            try
            {
                repository.Update(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
