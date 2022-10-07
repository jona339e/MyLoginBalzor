using Microsoft.Data.SqlClient;

namespace MyLogin.Data
{
    public class LoginClass
    {
        private string username;
        private string password;
        public LoginClass(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LoginDB;User ID=sa;Password=Passw0rd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            SqlCommand command = new SqlCommand(
                "Select UserName, [Password] from MyLogin Where UserName = @loginUserName", conn);
            command.Parameters.AddWithValue("@loginUserName", username);
            command.Parameters.AddWithValue("@loginPassword", password);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(0) == username && reader.GetString(1) == password)
                    {
                        Console.WriteLine("Username and Password is correct");
                    }
                    else
                    {
                        Console.WriteLine("Username or Password is incorrect");
                    }

                    //Console.WriteLine($"{reader["UserName"]}");
                }
            }

            conn.Close();
        }

    }
}
