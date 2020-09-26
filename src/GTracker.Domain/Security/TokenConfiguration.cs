namespace GTracker.Domain.Security
{
    public class TokenConfiguration
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double Minuts { get; set; }
    }
}