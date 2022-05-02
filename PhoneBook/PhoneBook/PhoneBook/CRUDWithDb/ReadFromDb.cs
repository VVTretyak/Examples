using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace PhoneBook.Controllers
{
    class ReadFromDb
    {
        private string searchString;
        private static bool flag = false;
        public List<Person> ReadAllStart()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var people = db.People.Include(p => p.PhoneNumbers).Include(p => p.EmailAddresses).ToList();
                return people;
            }
        }

        public async Task<List<Person>> ReadAllStartAsync()
        {          
           return await Task.Run(() => ReadAllStart());
        }
    
      
        public List<Person> SearchPersonAllMatches(string searchString)
        {
            this.searchString = searchString;
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var personPhone = (from persons in db.People.Include(p => p.PhoneNumbers).Include(p => p.EmailAddresses)
                                    where Compare(persons.PhoneNumbers, persons.EmailAddresses,persons.Id, 
                                    persons.FirstName, persons.SurName, searchString)
                                    select persons).ToList();

                return personPhone;
            }
        }
      
        private bool Compare(List<PhoneNumber> peoplePhones, List<EmailAddress> emailAddresses,int id, string firstName, string surName, string searchString)
        {
            flag = false;
            string patternEmail = "[a-zA-Z1-9\\-\\._]+@[a-z1-9]+(.[a-z1-9]+){1,}";//Паттерн для эмайла
            string patternPhone = "[0-9]{5,12}$";//цифры от 5 до 12 символов
            string patternId = "[0-9]{1,4}$";
            string patternFirstNameAndSurName = "^[А-Яа-яёЁA-Za-z]+$";//строка содержит только буквы          
            string[] patterns = new string[] { patternFirstNameAndSurName, patternPhone, patternEmail, patternId };
            string strId = id.ToString();      
            switch (IndexOfOperation(searchString, patterns))
            {
                case 0:
                    if (searchString == firstName || searchString == surName) flag = true;
                    break;
                case 1:
                    MatchSearch(peoplePhones);                   
                    break;
                case 2:                 
                    MatchSearch(emailAddresses);
                    break;
                case 3:
                    if (searchString == strId) flag = true;
                    break;

                default:
                    flag = false;
                    break;
            }
            return flag;        
        }

        //Определяем нужную операцию
        private int IndexOfOperation(string searchString, string[] patterns)
        {
            int OperationIndex = -1;
            for (int i = 0; i < patterns.Length; i++)
            {
                MatchCollection matches = Regex.Matches(searchString, patterns[i]);
                if (matches.Count > 0 && OperationIndex == -1) OperationIndex = i;
            }
            return OperationIndex;
        }

        private bool MatchSearch(List<PhoneNumber> phoneNumbers)
        {           
            foreach (var item in phoneNumbers)
            {
               if (searchString == item.Number) flag = true;
            };
            return flag;
        }

        private bool MatchSearch(List<EmailAddress> emailAddresses)
        {         
            foreach (var item in emailAddresses)
            {
               if (searchString == item.EmailLogin) flag = true;
            };
            return flag;
        }       
    }
}
