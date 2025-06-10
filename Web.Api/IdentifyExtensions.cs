namespace Web.Api;

public static class IdentifyExtensions
{
    public static string? GetUserId(this HttpContext context)
    {
        var userId = context.User.Claims.SingleOrDefault(x => x.Type == "userId");

        if (userId == null)
        {
            return null;
        }
        
        return userId.Value;
    }
}