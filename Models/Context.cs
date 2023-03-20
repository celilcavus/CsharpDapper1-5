using System.Data.SqlClient;

namespace DbContext
{
    public class Context{
        
        //Connection stringi Static oluşturdum Context classını newlemeden kullanmak için.
        public static SqlConnection connect = new SqlConnection(@"Server=.;Database=ExampleForDapper;Trusted_Connection=True;");
        
      

        
    }
}