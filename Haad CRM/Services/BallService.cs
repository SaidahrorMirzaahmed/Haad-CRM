using Haad_CRM.Helpers;
using Haad_CRM.Interfaces;
using Haad_CRM.Models.Ball;

namespace Haad_CRM.Services;

public class BallService : IBallService
{
    private readonly List<Ball> balls;
    public BallService()
    {
        balls = new List<Ball>();
    }
    public async Task<BallViewModel> CreateAsync(BallCreation ball)
    {
        var creationBall = balls.Create<Ball>(ball.MapTo<Ball>());

        return creationBall.MapTo<BallViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultBall = balls.FirstOrDefault(ball => ball.Id == id)
            ?? throw new Exception("Not found ball with this id");

        resultBall.IsDeleted = true;
        resultBall.DeletedAt = DateTime.UtcNow;

        return balls.Remove(resultBall);
    }

    public async Task<List<BallViewModel>> GetAllAsync()
    {
        return balls.MapTo<BallViewModel>();
    }

    public async Task<BallViewModel> GetByIdAsync(long id)
    {
        var resultBall = balls.FirstOrDefault(ball => ball.Id == id)
            ?? throw new Exception("Not found ball with this id");

        return resultBall.MapTo<BallViewModel>();
    }

    public async Task<BallViewModel> UpdateAsync(BallUpdate ball, long id)
    {
        var resultBall = balls.FirstOrDefault(ball => ball.Id == id)
            ?? throw new Exception("Not found ball with this id");

        resultBall.Id = id;
        resultBall.Comment = ball.Comment;
        resultBall.Comment = ball.Comment;
        resultBall.Comment = ball.Comment;
        resultBall.CoinMark = ball.CoinMark;
        resultBall.UpdateAt = DateTime.UtcNow;
        resultBall.TotalCoin = ball.TotalCoin;

        return resultBall.MapTo<BallViewModel>();
    }

}
