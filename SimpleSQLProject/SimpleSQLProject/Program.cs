using System;
using System.Data.SqlClient;

namespace SimpleSQLProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Połączenie się i otwarcie połączenia:
                var connectionParams = @"Server=.\MYSQLSERVER1; Database=MojeFinanse; Trusted_Connection=True;";

                using (var connection = new SqlConnection(connectionParams)) //gdy kod opuści blok using to połączenie zostanie automatycznie zamknięte
                {
                    connection.Open();

                    //Zapisanie komendy TSQL i wykonanie jej:
                    var sqlCommand = new SqlCommand("SELECT IDKlienta,Imie,Nazwisko,Inicjaly FROM Klienci", connection);

                    using (var reader = sqlCommand.ExecuteReader()) //metoda ExecuteReader zbuduje nam SqlDataReader
                    {
                        while (reader.Read()) //jeżeli jest dostępny następny rekord to wartość jest true
                        {
                            Console.WriteLine($"{reader[0],-5} {reader[1],-10} {reader[2],-10} {reader[3],-10}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Problem z uruchomieniem kodu TSQL " + ex.Message);
            }
        }
    }
}
