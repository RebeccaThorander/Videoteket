using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

DotNetEnv.Env.Load();
string connection = Environment.GetEnvironmentVariable("DB_CONNECTION")
      ?? throw new Exception("DB_CONNECTION saknas!")
    ;

using IDbConnection db = new MySqlConnection(connection);
db.Open();
var movies = db.Query<Movie>("SELECT Id, Titel FROM Movie").ToList();

foreach (Movie m in movies)
{
    Console.WriteLine($"{m.Id}: {m.Titel} ");
}
