using api.DBConnect;
using api.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class GetAllUserData : IGetAllUsers, IGetUser, IAuthenticateUser
    {
        public User AuthenticateUser(string username, string password)
        {
            DBConnection db = new DBConnection(); 
            User authUser = new User(){};
            bool isOpen = db.OpenConnection(); 
            if (isOpen){
                MySqlConnection conn = db.GetConn(); 
                string stm = "SELECT * FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(stm, conn); 
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Prepare(); 
                using(var rdr = cmd.ExecuteReader()){
                    while (rdr.Read())
                    {
                        authUser.Username=rdr.GetString(3);
                        authUser.Password=rdr.GetString(4);
                        if (authUser.Username != null)
                        {
                            authUser.Id = rdr.GetInt32(0); 
                            authUser.FName = rdr.GetString(1);
                            authUser.LName = rdr.GetString(2);
                            authUser.Username = rdr.GetString(3);
                            authUser.Password=rdr.GetString(4);
                        }else
                        {
                            return null; 
                        }
                    }
                }
                db.CloseConnection(); 
                return authUser; 
            }else{
                return null; 
            }  
        }

        public List<User> GetAllUsers()
        {
            DBConnection db = new DBConnection(); 
            bool isOpen = db.OpenConnection(); 
            if (isOpen){
                MySqlConnection conn = db.GetConn(); 
                string stm = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(stm, conn); 
                List<User> allUsers = new List<User>(); 
                using(var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        allUsers.Add(new User(){Id=rdr.GetInt32(0), FName=rdr.GetString(1), LName=rdr.GetString(2), Username=rdr.GetString(3), Password=rdr.GetString(4)}); 
                    }
                   
                }
                db.CloseConnection(); 
                return allUsers; 
            } else{
                return new List<User>(); 
            }
        }

        public User GetUser(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
