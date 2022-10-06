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
            SqlConnection conn = new SqlConnection("Data Source=192.168.2.2;Initial Catalog=LoginDB;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            SqlCommand command = new SqlCommand(
                "Select LoginUser from [Table]", conn);
            //    "Select LoginUser from [Table] where LoginUser=@userlogin", conn);
            command.Parameters.AddWithValue("@userlogin", username);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["LoginUser"]));
                }
            }

            conn.Close();
        }

    }
}
