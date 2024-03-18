using Microsoft.EntityFrameworkCore;

namespace ClientsBaseApplication.Data
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(GetPersons());
            base.OnModelCreating(modelBuilder);
        }

        private Person[] GetPersons()
        {
            return new Person[]
            {
                new Person { Id = 1, FullNamePerson = "Иванов Иван Иванович", Age = 30, Gender = "М", Phone =5555},
                new Person { Id = 2, FullNamePerson = "Петров Петр Петрович", Age = 35, Gender = "М", Phone =59090},
                new Person { Id = 3, FullNamePerson = "Сидоров Сидор Сидорович", Age = 63, Gender = "М", Phone =22345},
                new Person { Id = 4, FullNamePerson = "Иванова Мария Ивановна", Age = 70, Gender = "Ж", Phone =57700},
            };
        }
    }
}
