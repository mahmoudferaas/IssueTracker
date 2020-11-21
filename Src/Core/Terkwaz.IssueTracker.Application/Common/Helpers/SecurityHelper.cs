using System.Text;

namespace Terkwaz.IssueTracker.Application.Common.Helpers
{
    public static class SecurityHelper
    {
        public static string HashText(string value)
        {
            var crypt = System.Security.Cryptography.SHA512.Create();

            return Encoding.UTF8.GetString(crypt.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}