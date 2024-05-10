namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string? NomeCargo { get; set; }
        public ICollection<Colaborador>? Colaboradores { get; set; }
    }
}
