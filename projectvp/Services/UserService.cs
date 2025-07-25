using projectvp.Models;
using Microsoft.Data.SqlClient;

public class UserService
{
    private readonly string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<bool> RegisterUser(User user)
    {
        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            // Use brackets [] for column names with spaces
            string query = "INSERT INTO Signup ([FullName], [PhoneNumber], [Email], [Password]) VALUES (@FullName, @PhoneNumber, @Email, @Password)";
            using SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@FullName", user.Name);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            int result = await cmd.ExecuteNonQueryAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message); // Log the actual error
            return false;
        }
    }

    public async Task<bool> LoginUser(string email, string password)
    {
        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT COUNT(*) FROM Signup WHERE Email = @Email AND Password = @Password";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            int count = (int)await cmd.ExecuteScalarAsync();
            return count > 0;
        }
        catch
        {
            return false;
        }
    }


}
