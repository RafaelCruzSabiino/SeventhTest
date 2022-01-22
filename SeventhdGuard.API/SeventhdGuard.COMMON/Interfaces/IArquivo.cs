
namespace SeventhdGuard.COMMON.Interfaces
{
    public interface IArquivo
    {
        bool Upload(string path, string name, byte[] file);
        bool Delete(string path, string nameWithExtension);
        byte[] Get(string path, string nameWithExtension);
    }
}
