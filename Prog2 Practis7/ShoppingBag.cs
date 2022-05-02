namespace Prog2_Practis7
{
    public class ShoppingBag
    {
        public Article[] articles;

        public double Weight
        {
            get
            {
                double weight = 0;

                foreach (Article article in articles)
                    weight += article.Price;

                return weight;

            }
        }

        public string Content
        {
            get
            {
                string content = "";

                foreach (Article article in articles)
                    content += article + "\n";

                return content;
            }
        }
    }
}
