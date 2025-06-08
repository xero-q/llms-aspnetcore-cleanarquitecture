namespace LLMStudio;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class ModelTypes
    {
        private const string Base = $"{ApiBase}/model-types";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:int}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:int}}";
        public const string Delete = $"{Base}/{{id:int}}";
    }
    
    public static class Models
    {
        private const string Base = $"{ApiBase}/models";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:int}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:int}}";
        public const string Delete = $"{Base}/{{id:int}}";
    }
    
    public static class Users
    {
        private const string Base = $"{ApiBase}/users";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:int}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:int}}";
        public const string Delete = $"{Base}/{{id:int}}";
    }
    
    public static class Auth
    {
        private const string Base = $"{ApiBase}/auth";

        public const string Login = $"{Base}/login";

    }
}