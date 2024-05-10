using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Colaborador
    {
        public string? Id { get; set; }
        public int CargoId { get; set; }
        public bool Administrador { get; set; }


    }
}
