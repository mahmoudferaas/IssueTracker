﻿namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos
{
    public class BaseUserOutput
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}