

namespace Leilum.Data.DAOS
{
    internal class ArtigoDAO
    {
        private static ArtigoDAO? singleton = null;

        public static ArtigoDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new ArtigoDAO();
            }
            return singleton;
        }

        
    }
}
