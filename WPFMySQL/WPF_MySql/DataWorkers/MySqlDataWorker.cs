using System.Collections.Generic;
using System.Linq;
using WPF_MySql.Context;
using WPF_MySql.Model;

namespace WPF_MySql.DataWorkers
{
    public static class MySqlDataWorker
    {

        public static string CreatePerson(string name,string phone)
        {
            string result = "Уже существует";

            using(var repos = new WPF_MySqlContext())
            {
                bool checkIsExist = repos.Person.Any(p => p.Name == name);
                if (!checkIsExist)
                {
                    repos.Person.Add(new Model.Person() { Name = name, Phone = phone });
                    repos.SaveChanges();
                    result = "Добавлено";
                }
            }
            return result;
        }

        public static string DeletePerson(Person person)
        {
            string result = "Не найден";

            using (var repos = new WPF_MySqlContext())
            {
                bool checkIsExist = repos.Person.Any(p => p.Name == person.Name);
                if (checkIsExist)
                {
                    repos.Person.Remove(person);
                    repos.SaveChanges();
                    result = "Удалено";
                }
            }
            return result;
        }

        public static string EditPerson(Person person)
        {
            string result = "Не найден";

            using (var repos = new WPF_MySqlContext())
            {
                bool checkIsExist = repos.Person.Any(p => p.Id == person.Id);
                if (checkIsExist)
                {
                    repos.Person.Update(person);
                    repos.SaveChanges();
                    result = "Изменено";
                }
            }
            return result;
        }

        public static List<Person> GetAllPersons()
        {
            List<Person> result = new List<Person>();   
            using (var repos = new WPF_MySqlContext())
            {
                result = repos.Person.OrderBy(p => p.Id).ToList();
            }
            return result;
        }

        public static bool CheckConnectionToDb()
        {
            bool result = false;
            using (var repos = new WPF_MySqlContext())
            {
                result = repos.Database.CanConnect();
            }
            return result;
        }
    }
}
