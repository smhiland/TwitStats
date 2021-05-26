namespace TwitConsole
{
    internal class TwitAPICredentials : TwitStream.Core.ICredentials
    {
        public string Key { get; set; }
        public string Secret { get; set; }
        public string BearerToken { get; set; }
    }
}
