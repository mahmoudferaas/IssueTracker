namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos
{
    public class LoginOutput 
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}