namespace Prog2_Practis7
{
    public class Program
    {
        static void Main()
        {
            ShoppingBag bag = new ShoppingBag();
            bag.articles = new Article[] {
                new ArticleBook("Life of Pie", "Marvin Fette", "EMO Verlag", 1, 10),
                new ArticleCD("Marvin Fette", "Life is Life", 4, 2, 15),
                new ArticleVideo("Pie of Life", "Marvin Fette", false, 3, 20)
            };

            Console.WriteLine($"Gesamtwert: {bag.Weight}€");
            Console.WriteLine(bag.Content);
        }
    }
}