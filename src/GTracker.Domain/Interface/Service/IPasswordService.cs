namespace GTracker.Domain.Interface.Service
{
    public interface IPasswordService
    {
        string Hash(string password);
        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}