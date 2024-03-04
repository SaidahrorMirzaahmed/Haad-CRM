using Haad_CRM.Models.Ball;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class RatingReader
{
    public List<Ball> GetBallList()
    {
        List<Ball> ballList = new List<Ball>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, CoinMark, Comment, TotalCoin, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Rating";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ball ball = new Ball
                {
                    Id = reader.GetInt64(0),
                    CoinMark = reader.GetInt32(1),
                    Comment = reader.GetString(2),
                    TotalCoin = reader.GetInt32(3),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(4),
                    CreatAt = reader.GetDateTime(5),
                    UpdateAt = reader.GetDateTime(6),
                    DeletedAt = reader.GetDateTime(7)
                };

                ballList.Add(ball);
            }

            reader.Close();
        }

        return ballList;
    }

}


