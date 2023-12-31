using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace FinControl.Shared.Extensions;

public static class StringExtensions
{
    public static string GetPasswordHash(this string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();

        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));

        return builder.ToString();
    }

    public static bool EmailIsValid(this string email)
    {
        try
        {
            return new MailAddress(email).Address == email;
        }
        catch
        {
            return false;
        }
    }
}