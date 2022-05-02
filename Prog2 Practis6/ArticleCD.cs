namespace Prog2_Practis6
{
    public class ArticleCD : Article
    {
        public string Singer { get; private set; }

        public string AlbumName { get; private set; }

        public uint SongCount { get; private set; }

        public ArticleCD(string singer, string albumName, uint songCount, uint article, uint price) : base(article, price)
        {
            Singer = singer;
            AlbumName = albumName;
            SongCount = songCount;
        }
    }
}
