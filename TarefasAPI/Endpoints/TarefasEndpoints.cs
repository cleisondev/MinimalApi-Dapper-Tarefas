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

            app.MapGet("/tarefas/{id}", async (GetConnection connectiongetter, int id) =>
            {
                //Pegando a conexao
                using var con = await connectiongetter();
                //var tarefa = con.Get<Tarefa>(id); //Entrando no banco e trazendo a lista de dados da TB tarefas

                //if (tarefa is null)
                //    return Results.NotFound();

                return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound(); 
            });

            app.MapPost("/tarefas", async (GetConnection connectiongetter, Tarefa Tarefa) =>
            {
                using var con = await connectiongetter();
                var id = con.Insert(Tarefa);
                return Results.Created($"/tarefas/{id}", Tarefa);

                });

            app.MapPut("/tarefas", async (GetConnection connectiongetter, Tarefa Tarefa) =>
            {
                using var con = await connectiongetter();
                var id = con.Update(Tarefa);
                return Results.Ok();
            });


            app.MapDelete("/tarefas/{id}", async (GetConnection connectiongetter, int id) =>
            {
                //Pegando a conexao
                using var con = await connectiongetter();
                var deleted = con.Get<Tarefa>(id);

                if (deleted is null)
                    return Results.NotFound();

                con.Delete(deleted);
                return Results.Ok(deleted);
            });


        }
    }
}
