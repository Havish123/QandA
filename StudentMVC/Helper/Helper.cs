namespace StudentMVC.Helper
{
    public class StudentAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44322/");
            return client;
        }
    }
}
