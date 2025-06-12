namespace SharedKernel;

public static class ErrorMessages
{
    public const string ModelTypeNameNotEmpty = "ModelType's Name can not be empty.";
    public const string UsernameAlreadyExists = "Username already taken.";
    public const string UsernameNotEmpty = "Username can not be empty.";
    public const string PasswordNotEmpty = "Password can not be empty.";
    public const string TemperatureBetweenZeroOne = "Temperature must be between 0 and 1.";
    public const string ModelTypeNotFound = "Model type not found.";
    public const string ThreadTitleNotEmpty = "Thread's title can not be empty.";
    public const string TokenHasNotUserId = "Token has not UserId.";
    public const string TokenInvalidUserId = "Token has an invalid UserId";
    public const string TokenInvalidUser = "Password has an invalid Password";
    public const string ThreadSameTitleExists = "Thread's title already exists.";
    public const string UsernamePasswordInvalid = "Username and password do not match.";
    public const string TokenNotGenerated = "Token could not be generated.";
    public const string PromptNotCreated = "Could not create prompt.";
    public const string ErrorRequestLLM = "Error while making request to LLM";
}