using SeventhdGuard.COMMON.Interfaces;
using System.IO;

namespace SeventhdGuard.COMMON
{
    public class Arquivo : IArquivo
    {
        #region "Public Methods"

        public bool Delete(string path, string nameWithExtension)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    File.Delete(string.Format("{0}\\{1}", path, nameWithExtension));

                    if (Get(path, nameWithExtension) == null)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch 
            {
                return false;
            }
        }

        public byte[] Get(string path, string nameWithExtension)
        {
            try
            {
                if (Directory.Exists(path)) 
                {
                    var arquivo = File.ReadAllBytes(string.Format("{0}\\{1}", path, nameWithExtension));

                    if (arquivo.Length > 0)
                    {
                        return arquivo;
                    }
                }

                return null;
            }
            catch 
            {
                return null;
            }
        }

        public bool Upload(string path, string nameWithExtension, byte[] file)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    File.WriteAllBytes(string.Format("{0}\\{1}", path, nameWithExtension), file);

                    if (Get(path, nameWithExtension) != null)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch 
            {
                return false;
            }
        }

        #endregion
    }
}
