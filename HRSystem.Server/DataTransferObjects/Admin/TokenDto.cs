namespace HRSystem.Server.DataTransferObjects.Admin
{

    public record TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string? UserName { get; init; }
        public string Id { get; init; }

        public string? Email { get; init; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
