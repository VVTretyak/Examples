using AutoMapper;
using Mapper.Models;
using Mapper.ViewModels;
using System;

namespace ConsoleApp8
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonView>());         
            config.CreateMapper();
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(config);
            Person person = new Person();
            var viewPerson = mapper.Map<PersonView>(person);
               Console.WriteLine($"Name-{viewPerson.Name}-PhoneNumber-{viewPerson.PhoneNumber}");
            Console.ReadLine();
        }
    }
}
