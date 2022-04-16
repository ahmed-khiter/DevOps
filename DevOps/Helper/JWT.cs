namespace DevOps.Helper
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        //Expiring token
        public double DurationInDays { get; set; }

    }
}
