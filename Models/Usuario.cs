namespace ProjetoPortifolio.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }

        public string password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
