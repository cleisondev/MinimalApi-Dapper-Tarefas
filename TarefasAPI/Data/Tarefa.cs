using Dapper.Contrib.Extensions;

namespace TarefasAPI.Data;

[Table("Tarefas")]
public record Tarefa(int Id, string Atividade, string Status); //Novo recurso, dados leves, imutável, seguro pra threads.
