namespace Prog2_Practis7
{
    public class ArticleVideo : Article
    {
        private string _title;

        private string _director;

        private bool _availableAsDLC;

        public ArticleVideo(string title, string director, bool availableAsDLC, uint article, double price) : base(article, price)
        {
            _title = title;
            _director = director;
            _availableAsDLC = availableAsDLC;
        }

        public override string ToString()
        {
            return $"Titel: {_title}, Regisseur: {_director}, Als DLC verfügbarr: {(_availableAsDLC ? "Ja" : "Nein")}, " + base.ToString();
        }
    }
}
