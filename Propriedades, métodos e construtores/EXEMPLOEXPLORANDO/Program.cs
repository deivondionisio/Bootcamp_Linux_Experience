using ExemploExplorando.Models;

Pessoa p1 = new Pessoa();

p1.Nome = "David";
p1.Sobrenome = "Dionisio";
p1.Idade = 32;
p1.apresentar();

Pessoa p2 = new Pessoa();
p2.Nome = "Anderson";
p2.Sobrenome = "Dionisio";
p2.Idade = 45;
p2.apresentar();

Curso cursoDeIngles = new Curso();
cursoDeIngles.Nome = "Inglês";
cursoDeIngles.Alunos = new List<Pessoa>();

cursoDeIngles.AdicionarAluno(p1);
cursoDeIngles.AdicionarAluno(p2);
cursoDeIngles.ListarAlunos();

//Pessoa p1 = new Pessoa();

//p1.Nome = "David";
//p1.Sobrenome = "Dionisio";
//p1.Idade = 32;
//p1.apresentar();