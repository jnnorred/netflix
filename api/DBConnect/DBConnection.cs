using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api.DBConnect
{
    public class DBConnection
    {
        private MySqlConnection connection; 
        private string server; 
        private string database; 
        private string username; 
        private string password; 
        private string port; 

        public DBConnection(){
            Initialize();
        }
        private void Initialize (){
            server = "nnsgluut5mye50or.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "yyplawnqfsl9s8gq";
            port = "3306";
            username = "hsa84supf1f882dk"; 
            password = "uyamzqcvwe2diitj"; 

            string cs = $@"server = {server};user={username};database={database};port={port};password={password};";
            connection = new MySqlConnection(cs); 
        }
        public bool OpenConnection(){
            try{
                connection.Open(); 
                return true; 
            }
            catch(MySqlException ex){
                if(ex.Number == 0){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Cannot Connect"); 
                } else{ 
                    if(ex.Number == 1045){
                        Console.WriteLine("Invalid username/password"); 
                    }
                }
            }
            return false;
        }
        public bool CloseConnection(){
            try{
                connection.Close(); 
                return true; 
            }
            catch(MySqlException ex){
                Console.WriteLine(ex.Message);
            }
            return false; 
        }
        public MySqlConnection GetConn(){
            return connection; 
        }
    }
}