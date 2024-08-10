namespace Authentication.Api.DTO
{
    public class RegisterDTO : LoginDTO
    {
        public string Email { get; set; } = null!;
        public Guid Tenant { get; set; }
        public string Badge { get; set; } = null!;
    }
}
