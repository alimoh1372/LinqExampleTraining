using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\ALI2012SQLINSTAN;Initial Catalog=ContactDb;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * FROM Persons;";
            SqlDataAdapter sqlDaAd = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            sqlDaAd.Fill(dt);
            List<Person> Persons = new List<Person>();
            Persons = (from DataRow dr in dt.Rows
                       select new Person()
                       {
                           ID = Convert.ToInt32(dr["ID"]),
                           Name = dr["Name"].ToString(),
                           Family = dr["Family"].ToString(),
                           Age = Convert.ToInt32(dr["Age"]),
                           CtiyID = Convert.ToInt32(dr["CityID"]),
                           PhonNumber = dr["PhonNumber"].ToString(),
                           Mobile = dr["Mobile"].ToString(),
                           Email = dr["Email"].ToString(),
                           Address = dr["Address"].ToString()

                       }).ToList();
            string cityQuey = @"Select * From Cities;";
            sqlDaAd = new SqlDataAdapter(cityQuey, connection);
            dt = new DataTable();
            sqlDaAd.Fill(dt);

            List<City> cities = new List<City>();
            cities = (from DataRow c in dt.Rows
                      select new City
                      {
                          ID = Convert.ToInt32(c["ID"]),
                          Name = c["Name"].ToString(),
                          CityCodeNumber = c["CityCodeNumber"].ToString()
                      }).ToList();

            //Test Pure select

            // var result = (from n in Persons
            //               select n);


            //Lambda Expresion Simlpe Select
            //var result = Persons.Select(p => p);



            //Sql Server Simple Select
            //string queryTest = @"Select * From Persons";
            // SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest,connection);
            // DataTable dtTest = new DataTable();
            // dtAdTest.Fill(dtTest);


            //    //Test Sort With OrderBy,OrderByDescending in linq

            //var result = (from p in Persons
            //              orderby p.Name descending
            //              select p);
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("the result information");
            //int i = 0;
            //foreach (IPerson p in result)
            //{
            //    i++;
            //    Console.WriteLine($"{i}:{p.ID}-{p.Name}-{p.Family}-{p.Age}-{p.PhonNumber}-{p.Mobile}-{p.Email}-{p.Address} \n");

            //}


            //   //Lambda Expression
            //var lambdaResult = Persons.OrderByDescending(p => p.Name);
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("the result OF LAMBDA Expression  information");
            //int l = 0;
            //foreach (IPerson p in lambdaResult)
            //{
            //    l++;
            //    Console.WriteLine($"{l}:{p.ID}-{p.Name}-{p.Family}-{p.Age}-{p.PhonNumber}-{p.Mobile}-{p.Email}-{p.Address} \n");

            //}
            //    //Sort With orderBy,order By Descending in SQL
            //string queryTest = @"Select * From Persons
            //                      Order By Name DESC";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}-{p[1]}-{p[2]}-{p[3]}-{p[4]}-{p[5]}-{p[6]}-{p[7]}\n");
            //}






            ////using where in SQL SERVER
            //string queryTest = @"Select * From Persons As p
            //                    Where p.Name=N'علی'
            //                    Order By p.Age;";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}-{p[1]}-{p[2]}-{p[3]}-{p[4]}-{p[5]}-{p[6]}-{p[7]}\n");
            //}



            ////Using first() In Linq

            //var result = (from p in Persons
            //              where p.Age == 28
            //              select p).First() ;
            //Console.WriteLine("the result LINQ information");
            //int i = 0;
            //for ( i = 0; i < 1; i++)
            //{
            //    Console.WriteLine($"{i}:{result.ID}-{result.Name}-{result.Family}-{result.Age}-{result.PhonNumber}-{result.Mobile}-{result.Email}-{result.Address} \n");
            //}
            ////foreach (IPerson p in result)
            ////{
            ////    i++;
            ////    Console.WriteLine($"{i}:{p.ID}-{p.Name}-{p.Family}-{p.Age}-{p.PhonNumber}-{p.Mobile}-{p.Email}-{p.Address} \n");

            ////}

            ////using SImulate First() in SQL SERVER
            //string queryTest = @"select TOP 1 * From Persons p
            //                     where p.Age=28";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}-{p[1]}-{p[2]}-{p[3]}-{p[4]}-{p[5]}-{p[6]}-{p[7]}\n");
            //}



            ////Using Count() In Linq

            //var result = (from p in Persons
            //              where p.Name == "علی"
            //              select p).Count() ;
            //Console.WriteLine("the result LINQ information");
            //Console.WriteLine($"Count():{result.ToString()}");

            ////Simulate Count() in SQL SERVER
            //string queryTest = @"Select Count(*) from Persons p
            //                    Where p.Name=N'علی';";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}\n");
            //}


            ////Using Sum In Linq

            //var result = (from p in Persons

            //              select p.Age).Sum();
            //Console.WriteLine("the result LINQ information");
            //Console.WriteLine($"Max():{result.ToString()}");

            ////Simulate Sum in SQL SERVER
            //string queryTest = @"Select Sum(p.Age) from Persons p";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"Max(*):{p[0]}\n");
            //}



            ////Using Where In Linq

            //var result = (from p in Persons
            //              where p.Name.ToLower().Contains("ع")
            //              select p);
            //Console.WriteLine("the result LINQ information");
            //int i = 0;
            //foreach (IPerson p in result)
            //{
            //    i++;
            //    Console.WriteLine($"{i}:{p.ID}-{p.Name}-{p.Family}-{p.Age}-{p.PhonNumber}-{p.Mobile}-{p.Email}-{p.Address} \n");

            //}

            ////using where in SQL SERVER
            //string queryTest = @"Select * From Persons as p
            //                      Where p.Name Like N'%ع%'";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}-{p[1]}-{p[2]}-{p[3]}-{p[4]}-{p[5]}-{p[6]}-{p[7]}\n");
            //}

            //Test Sort With OrderBy,OrderByDescending in linq

            //var result = (from p in Persons
            //              where p.Name.ToLower().Contains("م");
            //              select p);
            ////Lambda Expression
            //var lambdaResult = Persons.Where(p => p.Name.Contains("م") || p.Family.Contains("م"));
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("the result OF LAMBDA Expression  information");
            //int l = 0;
            //foreach (IPerson p in lambdaResult)
            //{
            //    l++;
            //    Console.WriteLine($"{l}:{p.ID}-{p.Name}-{p.Family}-{p.Age}-{p.PhonNumber}-{p.Mobile}-{p.Email}-{p.Address} \n");

            //}



            ////using SImulate inner join in SQL SERVER
            //string queryTest = @"select TOP 1 * From Persons p
            //                     where p.Age=28";
            //SqlDataAdapter dtAdTest = new SqlDataAdapter(queryTest, connection);
            //DataTable dtTest = new DataTable();
            //dtAdTest.Fill(dtTest);
            //int j = 0;
            //Console.WriteLine("\n\nthe dataTable information");
            //foreach (DataRow p in dtTest.Rows)
            //{
            //    j++;
            //    Console.WriteLine($"{j}:{p[0]}-{p[1]}-{p[2]}-{p[3]}-{p[4]}-{p[5]}-{p[6]}-{p[7]}\n");
            //}



            //LINQ 
            var result = (from p in Persons
                          join c in cities
                          on p.CtiyID equals c.ID 
                          select new {p.ID,p.Name, CityCodeNumber=c.CityCodeNumber,CityName=c.Name,CityID=c.ID}
                        ).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("the result OF Linq   information");
            int l = 0;
            foreach (var p in result)
            {
                l++;
                Console.WriteLine($"{l}:{p.ID}-{p.Name}-{p.CityCodeNumber}-{p.CityName}-{p.CityID}\n");

            }
            //Lambda Expression
            var lambdaResult = Persons.Join(cities, p => p.CtiyID, c => c.ID, (p, c) => c);
        Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("the result OF LAMBDA Expression  information");
            l = 0;
            foreach (var p in lambdaResult)
            {
                l++;
                Console.WriteLine($"{l}:{p.ID}-{p.Name}-\n");

            }
            var result1 = Persons.Distinct();
    Console.ReadKey();
        }
    }
}
