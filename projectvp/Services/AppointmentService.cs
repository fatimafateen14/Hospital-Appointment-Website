using Microsoft.Data.SqlClient;
using projectvp.Models;

public class AppointmentService
{
    private readonly string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<bool> SaveAppointment(Appointment appointment)
    {
        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = "INSERT INTO Appointment (Name, Email, Phone, Doctor, Date) VALUES (@Name, @Email, @Phone, @Doctor, @Date)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", appointment.Name);
            cmd.Parameters.AddWithValue("@Email", appointment.Email);
            cmd.Parameters.AddWithValue("@Phone", appointment.Phone);
            cmd.Parameters.AddWithValue("@Doctor", appointment.Doctor);
            cmd.Parameters.AddWithValue("@Date", appointment.Date);

            int result = await cmd.ExecuteNonQueryAsync();
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

