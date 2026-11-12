namespace ProjetoPortifolio.Models
{
    public class Projeto
    {
        
            public int Id { get; set; }
            public string NomeAluno { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string TecnologiaUtilizada { get; set; }
            public string LinkAcesso { get; set; }
            public int Imagem { get; set; }
            public int Video { get; set; }
            public int AlunoId { get; set; }
        
    }
}
