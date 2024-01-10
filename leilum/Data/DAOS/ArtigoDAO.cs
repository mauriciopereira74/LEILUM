

namespace Leilum.Data.DAOS
{
    internal class ArtigoDAO
    {
        private static ArtigoDAO? singleton = null;

        public static ArtigoDAO getInstance()
        {
            if(this.singleton == null)
            {
                this.singleton = new ArtigoDAO();
            }
        }

        
    }
}
