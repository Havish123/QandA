namespace QandA_MVC.Helper
{
    public class QandA_API
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7060/");
            return client;
        }
    }
}
