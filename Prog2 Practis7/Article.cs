namespace Prog2_Practis7
{
    public class Article
    {
        private uint _articleID;

        private uint _price;

        public uint Price { get { return _price; } set { _price = value; } }

        public Article(uint article, uint price)
        {
            _articleID = article;
            _price = price;
        }

        public override string ToString()
        {
            return $"Artikelnummer: {_articleID}, Preis: {_price}";
        }
    }
}
