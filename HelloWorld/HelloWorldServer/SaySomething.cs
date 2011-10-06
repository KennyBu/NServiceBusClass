namespace HelloWorldServer
{
    public class SaySomething : ISaySomething
    {
        public string InResponseTo(string request)
        {
            return "Hello World!";
        }
    }
}