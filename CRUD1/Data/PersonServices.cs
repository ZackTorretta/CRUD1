using Microsoft.EntityFrameworkCore;
namespace CRUD1.Data
{
    public class PersonServices
    {
        #region Private members
        private PersonDBcontext dbContext;
        #endregion

        #region Constructor
        public PersonServices(PersonDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Person>> GetPersonAsync(string orderBy = "Person ID") //get here
        {
            
            return await dbContext.Person.ToListAsync();
        }
        
        public async Task<Person> GetSinglePerson(Guid id) //this is for updating. Gets the specific person in the table
        {
            var contact = await dbContext.Person.FindAsync(id);
            
            return contact;

        }
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

     
        /// This method update and existing product and saves the changes. EDIT
        
        /// <param name="p"></param>
        
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

       
        /// This method removes and existing product from the DbContext and saves it. DELETE
    
        /// <param name="person"></param>
       
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
