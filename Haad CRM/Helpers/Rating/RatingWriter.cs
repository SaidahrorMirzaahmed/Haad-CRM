using Haad_CRM.Models.Ball;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class RatingWriter
{
    public void UpdateBallList(List<Ball> newBallList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Ball table
            string deleteQuery = "DELETE FROM Ball";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newBallList
            foreach (Ball ball in newBallList)
            {
                string insertQuery = "INSERT INTO Rating (CoinMark, Comment, TotalCoin, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@CoinMark, @Comment, @TotalCoin, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@CoinMark", ball.CoinMark);
                insertCommand.Parameters.AddWithValue("@Comment", ball.Comment);
                insertCommand.Parameters.AddWithValue("@TotalCoin", ball.TotalCoin);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", ball.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", ball.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", ball.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", ball.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


