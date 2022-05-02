using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Controllers
{
    class DeleteFromDb
    {
        public void Delete(int id)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                Person person = db.People.Find(id);
                db.People.Remove(person);
                db.SaveChanges();               
            };
        }

        public void DeleteAll()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                List<Person> persons = db.People.Include(p => p.PhoneNumbers).Include(p => p.EmailAddresses).ToList();
                db.People.RemoveRange(persons);
                db.SaveChanges();               
            };
        }

        public async void DeleteAsync(int id)
        {
            await Task.Run(()=>Delete(id));            
        }

        public async void DeleteAllAsync()
        {
           // await Task.Run(() => DeleteAll());
            Task task = new Task(DeleteAll);
            task.Start();
            await task;
        }
    }
}
