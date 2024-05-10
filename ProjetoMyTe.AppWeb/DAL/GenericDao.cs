using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models.Contexts;

namespace ProjetoMyTe.AppWeb.DAL
{
    public class GenericDao<T> where T : class
    {
        public MyTeContext Context { get; set; }

        public GenericDao(MyTeContext context)
        {
            this.Context = context;
        }

        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }

        public T? Buscar(int id)
        {
            return Context.Set<T>().Find(id);
        }

        // Adicionar entidades
        public void Adicionar(T item)
        {
            //Context.Add<T>(item);
            Context.Entry<T>(item).State = EntityState.Added;
            Context.SaveChanges();
        }

        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remover(T item)
        {
            Context.Entry<T>(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
