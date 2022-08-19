using Microsoft.EntityFrameworkCore;
namespace CRUD1.Data
{
    public class PersonServices
    {
        //crud services
        #region Private members
        private PersonDBcontext dbContext;
        #endregion

        #region Constructor
        public PersonServices(PersonDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion
        //git test
        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPersonAsync() //get here
        {
            return await dbContext.Person.ToListAsync();
        }
        
        public async Task<Person> GetSinglePerson(Guid id)
        {
            var contact = await dbContext.Person.FindAsync(id);
            if (contact == null)
            {
                Console.WriteLine("null findasync");
            }
            else
            {
                Console.WriteLine(contact);
            }
            return contact;

        }
        /// <summary>
        /// This method add a new product to the DbContext and saves it. ADD here
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<Person> AddPersonAsync(Person person)
        {
            try
            {
                
                dbContext.Person.Add(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return person;
        }

        /// <summary>
        /// This method update and existing product and saves the changes. EDIT
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<Person> UpdatePersonAsync(Person person)
        {
            try
            {
                var productExist = dbContext.Person.FirstOrDefault(p => p.Id == person.Id);
                Console.WriteLine("EXIST IS", productExist);
                if (productExist != null)
                {
                    dbContext.Update(person);
                    Console.WriteLine("SAVING TO THE DATABASE");
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        /// <summary>
        /// This method removes and existing product from the DbContext and saves it. DELETE
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task DeletePersonAsync(Person person) //delete here
        {
            try
            {
                dbContext.Person.Remove(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
