namespace Villa_VillaAPI.Logging
{
    public interface ILogging
    {
        // type: information, error, ...
        public void Log(string message, string type);
    }
}
