using Entity;
using Dapper;
using System.Data.SqlClient;
using Repository.PersonRepository;

internal class Program
{
    private static void Main(string[] args)
    {
        // Dapper ile Database'imize FakeData ile 10.000 Adet data ekledik.
        for (int k = 0; k < 10; k++)
        {
            for (int i = 0; i < 1000; i++)
            {
                Person pers = new Person();
                pers.Name = FakeData.NameData.GetFirstName();
                pers.Lastname = FakeData.NameData.GetSurname();
                pers.PhoneNumber = FakeData.NumberData.GetNumber().ToString();
                PersonRepository.AddPerson(pers);
            };
        }

        // Db de çok fazla data bulunduğu için girilen değer kadar data getirmeisini istedim
        var model = PersonRepository.GetList(10);
        foreach (var item in model)
        {
            System.Console.WriteLine(string.Concat("ID : " + item.Id," Name : " + item.Name," Lastname : " + item.Lastname," Number : " + item.PhoneNumber));
        }

        // Idsi 1 ile 20 arasındaki dataları getirilicek.
        var model1 = PersonRepository.GetList().Where(x => x.Id >= 1 && x.Id <= 20);
        foreach (var item in model1)
        {
            System.Console.WriteLine(string.Concat("ID : " + item.Id, " Name : " + item.Name, " Lastname : " + item.Lastname, " Number : " + item.PhoneNumber));
        }

        // Databasedeki ilk elemanı döndürür.
         var model2 = PersonRepository.GetList().First();
        System.Console.WriteLine(string.Concat("ID : " + model2.Id, " Name : " + model2.Name, " Lastname : " + model2.Lastname, " Number : " + model2.PhoneNumber));    

        // Databasedeki son elemanı döndürür.
         var model3 = PersonRepository.GetList().Last();
        System.Console.WriteLine(string.Concat("ID : " + model3.Id, " Name : " + model3.Name, " Lastname : " + model3.Lastname, " Number : " + model3.PhoneNumber));    
    }
}
