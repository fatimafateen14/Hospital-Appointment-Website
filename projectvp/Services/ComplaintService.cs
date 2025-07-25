using Microsoft.Data.SqlClient;
using projectvp.Models;

public class ComplaintService
{
    private readonly string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<bool> SubmitComplaint(Complaint complaint)
    {
        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = "INSERT INTO Complaints (Id, Complaints) VALUES (@Id, @Complaints)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", complaint.Id);
            cmd.Parameters.AddWithValue("@Complaints", complaint.Complaints);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        catch
        {
            return false;
        }
    }
}
