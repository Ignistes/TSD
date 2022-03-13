using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using System;
using TSD.Linq.Task1.Lib.Model;
using System.Threading.Tasks;
using System.Linq;

namespace TSD.Linq.Task1.Lib.Test
{
    public class Main
    {
        public static void main()
        {
            System.Console.WriteLine("blabla");
        }

        [Test]
        public async Task GetTOP3BOTTOM3()
        {
            GoldClient client = new GoldClient();

            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));

            IEnumerable<GoldPrice> top3Query =
            from price in prices
            orderby price.Price descending
            select price;

            IEnumerable<GoldPrice> bottom3Query =
            from price in prices
            orderby price.Price ascending
            select price;

            List<GoldPrice> top3 = top3Query.Take(3).ToList();
            List<GoldPrice> bottom3 = bottom3Query.Take(3).ToList();

            System.Console.WriteLine("TOP3");
            System.Console.WriteLine(top3[0].Price);
            System.Console.WriteLine(top3[0].Date);
            System.Console.WriteLine(top3[1].Price);
            System.Console.WriteLine(top3[1].Date);
            System.Console.WriteLine(top3[2].Price);
            System.Console.WriteLine(top3[2].Date);

            System.Console.WriteLine("BOTTOM3");
            System.Console.WriteLine(bottom3[0].Price);
            System.Console.WriteLine(bottom3[0].Date);
            System.Console.WriteLine(bottom3[1].Price);
            System.Console.WriteLine(bottom3[1].Date);
            System.Console.WriteLine(bottom3[2].Price);
            System.Console.WriteLine(bottom3[2].Date);

            /*
            List<GoldPrice> top3 = new List<GoldPrice>();
            List<GoldPrice> bottom3 = new List<GoldPrice>();
            for (int i = 0; i < prices.Count; i++)
            {
                if (top3.Count < 3) { top3.Add(prices[i]); }
                else
                {
                    if (prices[i].Price > top3[2].Price)
                    {
                        top3[2] = prices[i];
                    }
                }

                if (bottom3.Count < 3) { bottom3.Add(prices[i]); }
                else
                {

                    if (prices[i].Price < bottom3[2].Price)
                    {
                        bottom3[2] = prices[i];
                    }
                }

                top3.Sort((x, y) => y.Price.CompareTo(x.Price));
                bottom3.Sort((x, y) => x.Price.CompareTo(y.Price));


            }
            System.Console.WriteLine("TOP3");
            System.Console.WriteLine(top3[0].Price);
            System.Console.WriteLine(top3[0].Date);
            System.Console.WriteLine(top3[1].Price);
            System.Console.WriteLine(top3[1].Date);
            System.Console.WriteLine(top3[2].Price);
            System.Console.WriteLine(top3[2].Date);
            System.Console.WriteLine("BOTTOM3");
            System.Console.WriteLine(bottom3[0].Price);
            System.Console.WriteLine(bottom3[0].Date);
            System.Console.WriteLine(bottom3[1].Price);
            System.Console.WriteLine(bottom3[1].Date);
            System.Console.WriteLine(bottom3[2].Price);
            System.Console.WriteLine(bottom3[2].Date);
            */
        }

        [Test]
        public async Task Earn5percent()
        {
            GoldClient client = new GoldClient();
            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31));
            System.Console.WriteLine(prices[0].Date);


            IEnumerable<GoldPrice> fivePercentQuery =
            from price in prices
            where price.Price / prices[0].Price >= 1.05
            select price;

            List<GoldPrice> fiver = fivePercentQuery.Take(1).ToList();
            System.Console.WriteLine(fiver.Count);

            System.Console.WriteLine(prices[0].Date);
            System.Console.WriteLine(prices[0].Price);
            System.Console.WriteLine(fiver[0].Date);
            System.Console.WriteLine(fiver[0].Price);
        }

        [Test]
        public async Task SecondTens()
        {
            GoldClient client = new GoldClient();
            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31));
            List<GoldPrice> prices2020 = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31));
            List<GoldPrice> prices2021 = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));

            prices.AddRange(prices2020);
            prices.AddRange(prices2021);

            IEnumerable<GoldPrice> secondTen =
            from price in prices
            orderby price.Price descending
            select price;

            secondTen = secondTen.Skip(10);
            List<GoldPrice> secondTenList = secondTen.Take(3).ToList();

            System.Console.WriteLine(secondTenList[0].Price);
            System.Console.WriteLine(secondTenList[0].Date);
            System.Console.WriteLine(secondTenList[1].Price);
            System.Console.WriteLine(secondTenList[1].Date);
            System.Console.WriteLine(secondTenList[2].Price);
            System.Console.WriteLine(secondTenList[2].Date);

        }


    }
}
