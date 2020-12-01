using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearGifts
{
    public class Purchases
    {
        internal Shop Shop { get; set; }

        internal Purchases(Shop shop)
        {
            Shop = shop;
        }
        public void PurchasesGifts()
        {
            GiftLessTen();
            Console.WriteLine("\n");
            GiftForMom();
            Console.WriteLine("\n");
            GiftForSelf();
            Console.WriteLine("\n");
            GiftPriceFivety();
            Console.WriteLine("\n");
            GiftRandom();
            Console.WriteLine("\n");
            PriceAllGifts();
            Console.WriteLine("\n");
            PriceAllGiftsLessForty();
            Console.WriteLine("\n");
            GiftsLesstwentyFive();
        }

        private void GiftsLesstwentyFive()
        {
            var products = Shop.Products.Where(p => p.prices.price_min.amount <= 25);

            foreach (var product in products)
            {
                WriteConsole(product);
            }
        }

        private void PriceAllGiftsLessForty()
        {
            Double price = Shop.Products.Select(p => p.prices.price_min.amount).Where(p => p < 40).Aggregate((x, y) => x + y);
            Console.WriteLine($"Total price = {price}");
        }

        private void PriceAllGifts()
        {
            Double price = Shop.Products.Select(p => p.prices.price_min.amount).Aggregate((x, y) => x + y);
            Console.WriteLine($"Total price = {price}");
        }

        private void GiftRandom()
        {
            Random rnd = new Random();

            double money = 80;
            Product product = null;
            while (money > 0)
            {
                WriteConsole(product);
                var index = rnd.Next(0, Shop.Products.Count - 1);
                product = Shop.Products[index];
                money -= product.prices.price_min.amount;
            }
        }

        private void GiftPriceFivety()
        {
            var products = Shop.Products.OrderBy(p => p.prices.price_min.amount);

            double money = 50;

            foreach (var product in products)
            {
                money -= product.prices.price_min.amount;
                if (money > 0)
                    WriteConsole(product);
                else
                    return;
            }
        }

        private void GiftLessTen()
        {
            Console.Write("Gift less 10rub.: ");
            Console.WriteLine(Shop
                .Products
                .Where(p => p.prices.price_min.amount < 10)
                .FirstOrDefault()
                == null
                ?
                "No"
                :
                "Yes");
        }
        private void GiftForMom()
        {
            var mother = Shop
                        .Products
                        .Where(p => p.prices.price_min.amount
                        ==
                        Shop.Products.Min(p => p.prices.price_min.amount))
                        .First();

            Console.Write("Gift for Mother-in-law: ");
            WriteConsole(mother);
        }

        private void GiftForSelf() 
        {
            var self = Shop
                    .Products
                    .Where(p => p.prices.price_min.amount
                    ==
                    Shop.Products.Max(p => p.prices.price_min.amount))
                    .First();

            Console.Write("Gift for self: ");
            WriteConsole(self);
        }
        private static void WriteConsole(Product product)
        {
            Console.WriteLine(product?.prices.price_min.amount
                                        + " " +
                                        product?.name_prefix
                                        + " " +
                                        product?.full_name);
        }
    }
}
