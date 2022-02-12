namespace ProxyPatern.Models
{
   public class Person:IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
