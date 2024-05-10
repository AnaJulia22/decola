using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class CargosService
    {

        public GenericDao<Cargo> CargosDao { get; set; }

        public CargosService(MyTeContext context)
        {
            this.CargosDao = new GenericDao<Cargo>(context);
        }

        public IEnumerable<Cargo> Listar()
        {
            return this.CargosDao.Listar();
        }

        public Cargo? Buscar(int id)
        {
            return CargosDao.Buscar(id);
        }

        public void Incluir(Cargo cargo)
        {
            CargosDao.Adicionar(cargo);
        }

        public void Alterar(Cargo cargo)
        {
            CargosDao.Alterar(cargo);
        }

        public void Remover(Cargo cargo)
        {
            CargosDao.Remover(cargo);
        }
    }
}
