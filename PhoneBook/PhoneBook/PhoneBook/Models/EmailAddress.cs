namespace PhoneBook.Models
{
    public class EmailAddress 
    {
        public int Id { get; set; }
        public string EmailLogin { get; set; }
        public Person person { get; set; }
    }

}
