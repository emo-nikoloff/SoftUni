using System.Data;
using Microsoft.Data.SqlClient;

namespace Plan;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("<--------ADO.NET-------->"); /* библиотека, която предоставя възможност за комуникация с база данни, обработка на данните в базата и за работа с XML
                                                           Видове access модели:
                                                           - connected - правим връзка -> изпълняваме заявки -> когато приключим, прекратяваме връзката
                                                           - disconnected - правим връзка веднъж -> изпълняваме заявки -> връзката се прекратява автоматично след изпълнението на заявките
                                                           - ORM - работим директно с обекти в кода -> ORM автоматично ги превежда в SQL заявки и отваря връзка -> изпълнява ги и ни връща
                                                           резултатите като обекти (като управлява връзката скритo от нас)
                                                           Как работи всъщност библиотеката:
                                                           - приложението генерира заявка (с или без помощни инструменти (Entity Framework, LINQ...))
                                                           - заявката стига до ядрото на ADO.NET
                                                           - ADO.NET използва конкретен Data Provider (преводач(SqlClient, OleDB, Odbc...))
                                                           - provider-ът се свързва със съответния източник (SQL, XML, Excel...) и изпълнява операцията
                                                        */
        string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;Encrypt=False;"; /* специален string за свързване към база данни; има специален формат за всеки
                                                                                                      Data Provider/DB Server - https://www.connectionstrings.com/
                                                                                                   */

        using SqlConnection sqlConnection = new(connectionString);
        sqlConnection.Open();

        Console.WriteLine("Connection opened successfully.");

        string sqlQuery = @"SELECT
                                CONCAT([FirstName], ' ', [LastName]) AS [FullName],
                                [JobTitle],
                                [Salary]
                            FROM [Employees]
                            WHERE [Salary] > @salaryThreshold";

        SqlCommand sqlCommand = new(sqlQuery, sqlConnection);

        Console.Write("Enter salary limit to filter employees above the limit: ");
        // правилен начин за задаване на параметър от потребителя
        string salaryThreshold = Console.ReadLine();
        SqlParameter salaryParameter = new("@salaryThreshold", SqlDbType.Decimal);
        salaryParameter.Value = decimal.Parse(salaryThreshold);

        sqlCommand.Parameters.Add(salaryParameter);

        using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        int i = 1;
        while (sqlDataReader.Read())
        {
            string fullName = sqlDataReader.GetString(0);
            string jobTitle = sqlDataReader.GetString(1);
            decimal salary = sqlDataReader.GetDecimal(2);

            Console.WriteLine($"#{i++} {fullName} - {jobTitle} - {salary:f2}");
        }

        sqlDataReader.Close(); // не е задължително да се прави изрично Close, защото по подразбиране using би трябвало да затвори връзката
        sqlConnection.Close();

        Console.WriteLine("--------------------------------");

        Console.WriteLine("<--------Entity Framework Core-------->"); /* ORM(Object-Relational Mapping) data access model - играе ролята на мост между данните в релационния свят и данните в
                                                                         обектно-ориентирания свят - свързва таблиците от базата с класове и колоните с пропъртита. Всеки обект от класа
                                                                         представлява ред (запис) от таблицата. Работи с Shadow Copy (local copy) на данните - когато променяме данните в
                                                                         приложението, те не се променят директно в базата. Следи какви промени правим по данните и ги запазва - промените,
                                                                         които са локални, да бъдат пренесени в базата. Съществуват два начина на работа:
                                                                         - Code First(по-често срещан) - пишеш класове с пропъртита и според класовете се създава база данни
                                                                         - DB First - имаш готова база и от нея генерираш класове за всяка една таблица
                                                                         EF Core имплементира Unit of Work pattern - или всичко успява, или нищо.
                                                                      */
    }
}
