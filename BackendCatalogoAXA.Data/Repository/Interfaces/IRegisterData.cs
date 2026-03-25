namespace BackendCatalogoAXA.Model.Repository.Interfaces
{
    public interface IRegisterData
    {
        // Metodo de creacion para todas las tablas
        // <T> es un objeto que ya viene mapeado y se pasa al Repository
        //estudiar promesas 
        Task<bool> RegisterLogicAsync<T>(T registerObject);

    }
}
