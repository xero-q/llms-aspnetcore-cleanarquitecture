namespace Application.Helpers;

public static class JsonHelper
{
    public static string EscapeJsonString(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}