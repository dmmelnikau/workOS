using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workOS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace workOS.DataAccessLayer
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(
           DbContextOptions options) : base(options)
        {
            using (var connection = new SqliteConnection("Data Source=mydatabase.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE Task(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Description TEXT NOT NULL, LastVisit TEXT NOT NULL)";
                //command.ExecuteNonQuery();
            }

        }
    }
}
