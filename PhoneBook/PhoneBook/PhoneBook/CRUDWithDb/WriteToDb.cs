using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
namespace PhoneBook.Controllers
{
    public class WriteToDb
    {
        public string ControlerFirstName { get; set; }
        public string ControlerSurName { get; set; }
        public List<PhoneNumber> ControlerPhoneNumbers { get; set; }
        public List<EmailAddress> ControlerEmailAdresses { get; set; }

        public WriteToDb()
        {
            ControlerPhoneNumbers = new List<PhoneNumber>();
            ControlerEmailAdresses = new List<EmailAddress>();
        }

        public void WriteStart()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                db.People.Add
                (
                    new Person
                    {
                        FirstName = ControlerFirstName,
                        SurName = ControlerSurName,
                        PhoneNumbers = ControlerPhoneNumbers,
                        EmailAddresses = ControlerEmailAdresses
                    }
                );
                db.SaveChanges();
            };
        }

        public async void WriteStartAsync()
        {
            Task task = new Task(WriteStart);
            task.Start();
            await task;
        }

        public void UpdateDb(int id, List<string> CurrentLineData)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var person = (from persons in db.People.Include(p => p.PhoneNumbers).Include(p => p.EmailAddresses)
                              where (persons.Id == id)
                              select persons).FirstOrDefault();

                person.FirstName = CurrentLineData[0];
                person.SurName = CurrentLineData[1];
                person.PhoneNumbers[0].Number = CurrentLineData[2];
                person.PhoneNumbers[1].Number = CurrentLineData[3];
                person.EmailAddresses[0].EmailLogin = CurrentLineData[4];
                person.EmailAddresses[1].EmailLogin = CurrentLineData[5];
                db.UpdateRange(person);
                db.SaveChanges();
            }
        }
    }
}
