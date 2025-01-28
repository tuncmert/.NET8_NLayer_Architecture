namespace App.Repositories;

    public class UnityOfWork(AppDbContext context) : IUnityOfWork
{
    public Task<int> SaveChangeAsync()
    {
        return context.SaveChangesAsync();
    }
}

