namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class RegistroHora
    {
        public int Id { get; set; }
        public int IdWbs { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime Dia { get; set; }
        public int Horas { get; set; }
        public string? Cpf { get; set; }
    }
}
