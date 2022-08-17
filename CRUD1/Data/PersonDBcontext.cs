using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD1.Data
{
    public class PersonDBcontext : DbContext
    {
        #region Contructor
        public PersonDBcontext(DbContextOptions<PersonDBcontext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public DbSet<Person> Person { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(GetPerson());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
        DateTime thisDate2 = new DateTime(2011, 6, 10); //this = 6/10/2011 or june 10, 2011
        #region Private methods
        private List<Person> GetPerson()
        {
            return new List<Person>
            {
                //the ID is set to 1 for now and the datetime is set to 6/10/2011 for now. no CRUD yet.
                new Person { Id = ToGuid(1), LastName = "Torretta", FirstName = "Zack", PhoneNumber = "1231231234", BirthDate = thisDate2}
            };
            //    new Person { Id = 1002, Name = "Microsoft Office", Price = 20.99, Quantity = 50, Description ="This is a Office Application"},
            //    new Person { Id = 1003, Name = "Lazer Mouse", Price = 12.02, Quantity = 20, Description ="The mouse that works on all surface"},
            //    new Person { Id = 1004, Name = "USB Storage", Price = 5.00, Quantity = 20, Description ="To store 256GB of data"}
            //};
        }
        #endregion
    }
}
