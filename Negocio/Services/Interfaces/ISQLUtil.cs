namespace Negocio.Services.Interfaces
{
    public interface ISQLUtil
    {
        string CrearSchema(string nombre);
        string BorrarSchema(string nombre);
    }
}