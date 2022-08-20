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
        //DateTime thisDate2 = new DateTime(2011, 6, 10); //this = 6/10/2011 or june 10, 2011
        #region Private methods
        public List<Person> GetPerson()
        {
            return new List<Person>
            {
                //the ID is set to 1 for now and the datetime is set to 6/10/2011 for now. no CRUD yet.
                new Person { Id = ToGuid(1), LastName = "Torretta", FirstName = "Zack", PhoneNumber = "1231231234", BirthDate = new DateTime(2011, 6, 10)}
            };
        }
        #endregion
    }
}
