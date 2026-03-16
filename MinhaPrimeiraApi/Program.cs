// GET: Rotas de Leitura | POST: Gravação
var builder = WebApplication.CreateBuilder(args);

// 1. Configuração CORS: Permitir qeu páginas web leiam nossa API
builder.Services.AddCors(opcoes =>
{
    opcoes.AddDefaultPolicy(politica =>
    {
        politica.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseCors();

// -=- TABELA FAKE EM MEMÓRIA -=-
// Usamos List<Aluno> para adicionar quantos alunos quisermos ento a API roda
List<Aluno> tabelaAlunos = new List<Aluno>
{
    new Aluno {Nome = "João (Padrão)", Idade = 25, Matricula="WEB-001"}
};

// 2. Método GET: Devolve a lista completa de alunos para o site (Leitura)
app.MapGet("/aluno", () =>
{
    return Results.Ok(tabelaAlunos); //Retorna a lista como um array JSON
});

// 3. Método POST: Recebe um novo aluno do site, valida e adiciona na lista (Escrita)
app.MapPost("/aluno", (Aluno novoAluno) =>
{
    if (novoAluno.Idade <= 0)
        return Results.BadRequest("ERRO: A idade deve ser maior que zero!");
    if (string.IsNullOrEmpty(novoAluno.Nome)) 
        return Results.BadRequest("ERRO: o nome é obrigatório");

        //Gera uma matrícula falsa e adiciona na memória
            novoAluno.Matricula = $"WEB-00{tabelaAlunos.Count + 1}";
            tabelaAlunos.Add(novoAluno);
            return Results.Created($"/aluno/{novoAluno.Matricula}", novoAluno);
});

app.Run();


// -- CLASSES DE POO ---
public class Pessoa
{
    public string Nome {get; set; }
    public int Idade {get; set;}
}

public class Aluno:Pessoa
{
    public string Matricula {get; set;}
}