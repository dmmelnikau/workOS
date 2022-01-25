using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workOS.Model;

namespace workOS.DataAccessLayer
{
    public class TaskLayer
    {

        string connectionString = "Data Source=mydatabase.db";
        //To View all employees details
        public IEnumerable<Tasks> GetAllTasks()
        {
            try
            {
                List<Tasks> lsttask = new List<Tasks>();
                string sqlExpression = "SELECT * FROM Task";
                using (var con = new SqliteConnection(connectionString))
                {

                    SqliteCommand command = new SqliteCommand(sqlExpression, con);
                    con.Open();
                    SqliteDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        Tasks task = new Tasks();
                        task.TaskId = Convert.ToInt32(rdr["Id"]);
                        task.Name = rdr["Name"].ToString();
                        task.Description = rdr["Description"].ToString();
                        task.LastVisit = rdr["LastVisit"].ToString();
                        lsttask.Add(task);
                    }
                    con.Close();
                }
                return lsttask;
            }
            catch
            {
                throw;
            }
        }
        public int AddTask(Tasks tasks)
        {
            const string query = "INSERT INTO Task(Name, Description, LastVisit) VALUES(@Name, @Description, @LastVisit)";

            //here we are setting the parameter values that will be actually 
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
    {
        {"@Name", tasks.Name},
        {"@Decription", tasks.Description},
         {"@LastVisit", tasks.LastVisit}
    };

            return ExecuteWrite(query, args);
        }
        public int EditTask(Tasks task)
        {
            const string query = "UPDATE Task SET Name = @Name, Description = @Description, LastVisit = @LastVisit WHERE TaskId = @Id";

            //here we are setting the parameter values that will be actually 
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
    {
        {"@Id", task.TaskId},
        {"@Name", task.Name},
         {"@Description", task.Description},
        {"@LastVisit", task.LastVisit}
    };

            return ExecuteWrite(query, args);
        }
        public int DeleteTask(Tasks task)
        {
            const string query = "Delete from Task WHERE TaskId = @Id";

            //here we are setting the parameter values that will be actually 
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
    {
        {"@Id", task.TaskId}
    };

            return ExecuteWrite(query, args);
        }
        public Tasks GetTaskData(int id)
        {
            try
            {
                Tasks task = new Tasks();
                using (SqliteConnection con = new SqliteConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Task WHERE Id= " + id;
                    SqliteCommand cmd = new SqliteCommand(sqlQuery, con);
                    con.Open();
                    SqliteDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        task.TaskId = Convert.ToInt32(rdr["Id"]);
                        task.Name = rdr["Name"].ToString();
                        task.Description = rdr["Description"].ToString();
                       task.LastVisit = rdr["LastVisit"].ToString();
                    }
                }
                return task;
            }
            catch
            {
                throw;
            }
        }
        private int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;

            //setup the connection to the database
            using (var con = new SqliteConnection("Data Source=mydatabase.db"))
            {
                con.Open();

                //open a new command
                using (var cmd = new SqliteCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }

                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }

                return numberOfRowsAffected;
            }

        }
    }
}
