namespace Gestion.Models.Repositories
{
    public interface IRepositorie<T>
    {
        public void ajouter(T element);
        public void modifier(int id, T element);    
        public void supprimer(int id);
        IList<T> lister();
        T listerSelonId(int id);
    }
}
