namespace Prog2_Practis7
{
    public class ArticleCD : Article
    {
        private string _singer;

        private string _albumName;

        private uint _songCount;

        public ArticleCD(string singer, string albumName, uint songCount, uint article, double price) : base(article, price)
        {
            _singer = singer;
            _albumName = albumName;
            _songCount = songCount;
        }

        public override string ToString()
        {
            return $"Interpret: {_singer}, Albumname: {_albumName}, Anzahl der Lieder: {_songCount}, " + base.ToString();
        }
    }
}
