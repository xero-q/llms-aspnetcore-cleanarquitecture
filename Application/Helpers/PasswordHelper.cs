namespace Application.Helpers;

public static class PasswordHelper
{
   
    /// <summary>
    /// Hashes a plain-text password using bcrypt.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

 
    /// <summary>
    /// Verifies a plain-text password against a hashed password.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hashedPassword"></param>
    /// <returns></returns>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}