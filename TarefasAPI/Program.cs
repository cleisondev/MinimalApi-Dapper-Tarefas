using TarefasAPI.Endpoints;
using TarefasAPI.Extensions;

namespace TarefasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddPersistence();
            var app = builder.Build();
            app.MapTarefasEndpoints();


            app.Run();
        }
    }
}