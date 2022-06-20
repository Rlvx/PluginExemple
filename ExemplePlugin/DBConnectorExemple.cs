using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SDG.Unturned;

namespace ExemplePlugin
{
    public class DBConnectorExemple
    {
        public static Dictionary<string,List<List<string>>> RepQuery = new Dictionary<string, List<List<string>>>();
        public MySqlConnection CreateConnection()
        {
            MySqlConnection connection = null;
            try
            {
                string host = "";
                string databseName = "";
                string username = "";
                string password = "";
                string port = "3306";
                
                
                connection = new MySqlConnection($"SERVER={host};DATABASE={databseName};UID={username};PASSWORD={password};PORT={port};");
            }
            catch (Exception ex)
            {
                UnturnedLog.error("CreateConnection |" + ex);
                return connection;
            }
            return connection;

        }
        
       
        public List<List<string>> sync_query(string req)
        {

            MySqlConnection connection = CreateConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(req, connection);
                connection.Open();
                List<List<string>> infos = new List<List<string>>();
                if (connection.State == ConnectionState.Open)
                {
                    using (MySqlDataReader Lire = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (Lire.Read())
                        {
                            int j = 0;
                            infos.Add(new List<string>());
                            try
                            {
                                while (Lire[j] != null)
                                {
                                    infos[i].Add(Lire[j].ToString());
                                    j++;
                                }
                            }
                            catch (IndexOutOfRangeException){}
                            i++;
                        }

                        connection.Close();
                        return infos;
                    }
                }
                else
                {
                    connection.Close();
                    return infos;
                }
            }
            catch (Exception ex)
            {
                UnturnedLog.error("DatabaseFct.sync_query() | "+ex);
                connection.Close();
                return new List<List<string>>();
            }
     
        }
        
        public void query(Object details)
        {
            List<string> param = (List<string>) details;
            string key = param[0];
            string req = param[1];

            MySqlConnection connection = CreateConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(req, connection);
                connection.Open();
                List<List<string>> infos = new List<List<string>>();
                if (connection.State == ConnectionState.Open)
                {
                    using (MySqlDataReader Lire = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (Lire.Read())
                        {
                            int j = 0;
                            infos.Add(new List<string>());
                            try
                            {
                                while (Lire[j] != null)
                                {
                                    infos[i].Add(Lire[j].ToString());
                                    j++;
                                }
                            }
                            catch (IndexOutOfRangeException){}
                            i++;
                        }

                        
                        RepQuery[key] = infos;
                    }
                }
                else
                {
                    RepQuery[key] = infos;
                }
            }
            catch (Exception ex)
            {
                UnturnedLog.error("DatabaseFct.query() | "+ex);
                RepQuery[key] = new List<List<string>>(){new List<string>(){"error"}};
            }
            connection.Close();
        }
        
        public async Task<List<List<string>>> newquery(string req,string name = "query")
        {
            Random random = new Random();
            int key = 1;
            
            while (RepQuery.ContainsKey(key.ToString()))
            {
                key ++;
            }
            //UnturnedLog.error("-> Request "+name+" [id : "+key+"]");
            
            RepQuery.Add(key.ToString(), null);
            
            var t = new Thread(query);
            t.Start(new List<string>(){key.ToString(),req});
            
            while (RepQuery[key.ToString()] == null)
            {
                await Task.Delay(50);
            }
            
            t.Interrupt();

            List<List<string>> answer_query = new List<List<string>>();

            try
            {
                if (RepQuery[key.ToString()][0][0] != "error")
                {
                    answer_query = RepQuery[key.ToString()];
                }
            }
            catch
            {
                //UnturnedLog.error("-> null Query");
            }



            RepQuery.Remove(key.ToString());
            //UnturnedLog.error("-> Answer newquery "+key+" : OK !");
            return answer_query;
        }
        
        private void doquery(Object reqete)
        {
            string req = (string) reqete;
            try
            {
                MySqlConnection connection = CreateConnection();
                MySqlCommand cmd = new MySqlCommand(req, connection);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void newdoquery(string req)
        {
            var t = new Thread(doquery);
            t.Start(req);
        }
    }
}