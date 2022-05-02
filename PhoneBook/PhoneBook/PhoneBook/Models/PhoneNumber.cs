namespace PhoneBook.Models
{
    public class PhoneNumber 
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Person person { get; set; }
    } 

}
