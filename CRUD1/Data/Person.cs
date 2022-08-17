namespace CRUD1.Data
{
    public class Person
    {
        //******possible nullable issue. maybe later.******
        public Guid Id { get; set; } //globally unique. ID are unique
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
