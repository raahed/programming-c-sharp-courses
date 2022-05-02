namespace Prog2_Practis6
{
    public class ArticleVideo : Article
    {
        public string Title { get; private set; }

        public string Director { get; private set; }

        public bool AvailableAsDLC { get; private set; }

        public ArticleVideo(string title, string director, bool availableAsDLC, uint article, uint price) : base(article, price)
        {
            Title = title;
            Director = director;
            AvailableAsDLC = availableAsDLC;
        }
    }
}
