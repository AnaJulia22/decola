using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class RegistroHorasService
    {
        public GenericDao<RegistroHora> RegistrosDao { get; set; }

        public RegistroHorasService(MyTeContext context)
        {
            this.RegistrosDao = new GenericDao<RegistroHora>(context);
        }

        public IEnumerable<RegistroHora> Listar()
        {
            return this.RegistrosDao.Listar();
        }

        public RegistroHora? Buscar(int id)
        {
            return RegistrosDao.Buscar(id);
        }

        public void Incluir(RegistroHora registroHora)
        {
            RegistrosDao.Adicionar(registroHora);
        }

        public void Alterar(RegistroHora registroHora)
        {
            RegistrosDao.Alterar(registroHora);
        }

        public void Remover(RegistroHora registroHora)
        {
            RegistrosDao.Remover(registroHora);
        }
    }
}
