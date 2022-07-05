namespace api
{
    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public decimal AccountBalance { get; set; }
        public int NumberOfShares { get; set; }
    }
}
