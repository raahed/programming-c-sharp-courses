
namespace Prog2_Practis7
{
    public class ArticleBook : Article
    {
        private string _title;

        private string _author;

        private string _publisher;

        public ArticleBook(string title, string author, string publisher, uint article, double price) : base(article, price)
        {
            _title = title;
            _author = author;
            _publisher = publisher;
        }

        public override string ToString()
        {
            return $"Title: {_title}, Author: {_author}, Verlag: {_publisher}, " + base.ToString();
        }
    }
}
