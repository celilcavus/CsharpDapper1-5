
using Dapper;
using DbContext;
using Entity;

namespace Repository.PersonRepository
{
    public class PersonRepository
    {
        public static void AddPerson(Person person)
        {
            Context.connect.Execute($@"Insert into Person ( Name, Lastname, PhoneNumber) values 
            ('{person.Name}','{person.Lastname}','{person.PhoneNumber}')");
        }
        public static List<Person> GetList()
        {
            return Context.connect.Query<Person>($"Select * from Person").ToList();
        }
        public static List<Person> GetList(int? top)
        {
            return Context.connect.Query<Person>($"Select top {top} * from Person").ToList();
        }
    }
}