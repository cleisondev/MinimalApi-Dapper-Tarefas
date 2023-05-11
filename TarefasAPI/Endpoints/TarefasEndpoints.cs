using Dapper.Contrib.Extensions;
using TarefasAPI.Data;
using static TarefasAPI.Data.TarefaContext;

namespace TarefasAPI.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)//Metodo
        {
            app.MapGet("/", () => $"Bem vindo a API Tarefas {DateTime.Now}");//Retornando um texto pra verificar se está tudo certo

            //Get de tarefas, Usar contexto como params.
            app.MapGet("/tarefas", async (GetConnection connectiongetter) =>
            {
                //Pegando a conexao
                using var con = await connectiongetter();
                var tarefas = con.GetAll<Tarefa>().ToList(); //Entrando no banco e trazendo a lista de dados da TB tarefas
                
                if (tarefas is null)
                    return Results.NotFound();

                return Results.Ok(tarefas);
            });
        }
    }
}
