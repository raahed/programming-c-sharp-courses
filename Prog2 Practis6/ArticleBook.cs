
namespace Prog2_Practis6
{
    public class ArticleBook : Article
    {
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Publisher { get; private set; }

        public ArticleBook(string title, string author, string publisher, uint article, uint price) : base(article, price)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }
    }
}
