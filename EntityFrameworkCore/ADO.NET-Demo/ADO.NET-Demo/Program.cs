using System;
using System.Data.SqlClient;

namespace ADO.NET_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create connection
            using SqlConnection sqlConnection = new SqlConnection(Confing.ConnectionString);
            sqlConnection.Open();
            // We have opened connection
            // Then we need to create a command -> On add/update/delete we shoud use Transaction!! 
            // Interpolated string -> SQL Injection Possible
            // Parameters -> SQL Injection Impossible
            string jobTitle = Console.ReadLine();
            string query = @"SELECT[FirstName],[LastName],[JobTitle] FROM [Employees] WHERE [JobTitle] = @jobTitle";
            SqlCommand employeeInfoCmd = new SqlCommand(query, sqlConnection);
            employeeInfoCmd.Parameters.AddWithValue(@"jobTitle", jobTitle);
            using SqlDataReader employeeInfoReader = employeeInfoCmd.ExecuteReader();
            //Console.WriteLine(employeeCount);
            //---------------------
            
            //SqlCommand employeeInfoCmd = new SqlCommand(employeeInfoQuery, sqlConnection);
            //Read -> True (another rows)
            //Read -> False (last row)
            //While there are rows -> Go on the next row
            int rowNum = 1;
            while (employeeInfoReader.Read())
            {
                string firstName = (string)employeeInfoReader["FirstName"];
                string lastName = (string)employeeInfoReader["LastName"];
                string jobTitle1 = (string)employeeInfoReader["JobTitle"];
                Console.WriteLine($"#{rowNum++}. {firstName} {lastName} --- {jobTitle1}");
            }
            //Close
            employeeInfoReader.Close();
            // Debugging
            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue...");
        }
    }
}
