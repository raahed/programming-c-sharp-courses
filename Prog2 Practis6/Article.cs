namespace Prog2_Practis6
{
    public class Article
    {
        public uint ArticleID { get; private set; }
        
        public uint Price { get; private set; }
        
        public Article(uint article, uint price)
        {
            ArticleID = article;
            Price = price;
        }
    }
}
