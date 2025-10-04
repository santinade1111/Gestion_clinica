namespace Gestion_clinica.models
{
    public interface IRegistrable<T>
    {
        public void Register(T Entity);
    }
}