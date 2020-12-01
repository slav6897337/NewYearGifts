
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace NewYearGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Deserialazer(ref shop);

            Purchases purchases = new Purchases(shop);

            purchases.PurchasesGifts();

        }
        public static void Deserialazer(ref Shop shop)
        {
            string faileData;
            using (StreamReader fl = new StreamReader("PresentsJson.txt"))
            {
                faileData = fl.ReadToEnd();
            }

            shop = JsonConvert.DeserializeObject<Shop>(faileData);
        }
    }
}
