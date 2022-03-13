using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using System;
using TSD.Linq.Task1.Lib.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

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

        [Test]
        public async Task Average()
        {

            GoldClient client = new GoldClient();
            List<GoldPrice> prices2019 = await client.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31));
            List<GoldPrice> prices2020 = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31));
            List<GoldPrice> prices2021 = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));

            IEnumerable<double> prices2019Query =
            from price in prices2019
            select price.Price;

            prices2019Query.ToList();
            System.Console.WriteLine(prices2019Query.Average());

            IEnumerable<double> prices2020Query =
            from price in prices2020
            select price.Price;

            prices2020Query.ToList();
            System.Console.WriteLine(prices2020Query.Average());

            IEnumerable<double> prices2021Query =
            from price in prices2021
            select price.Price;

            prices2021Query.ToList();
            System.Console.WriteLine(prices2021Query.Average());

        }

        [Test]
        public async Task invest()
        {

            GoldClient client = new GoldClient();
            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31));
            List<GoldPrice> prices2020 = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31));
            List<GoldPrice> prices2021 = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));
            List<GoldPrice> prices2022 = await client.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13));

            prices.AddRange(prices2020);
            prices.AddRange(prices2021);
            prices.AddRange(prices2022);

            IEnumerable<GoldPrice> min =
            from price in prices
            orderby price.Price ascending
            select price;

            List<GoldPrice> minimum = min.Take(1).ToList();


            IEnumerable<GoldPrice> max =
            from price in prices
            orderby price.Price descending
            where price.Date.CompareTo(minimum[0].Date) > 0
            select price;

            List<GoldPrice> maximum = max.Take(1).ToList();

            System.Console.WriteLine("BUY");
            System.Console.WriteLine(minimum[0].Date);
            System.Console.WriteLine(minimum[0].Price);
            System.Console.WriteLine("SELL");
            System.Console.WriteLine(maximum[0].Date);
            System.Console.WriteLine(maximum[0].Price);
            System.Console.WriteLine("BENEFITS");
            System.Console.WriteLine(maximum[0].Price - minimum[0].Price);


        }

        [Test]
        public async Task ToXMLinit()
        {
            GoldClient client = new GoldClient();
            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31));
            List<GoldPrice> prices2020 = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31));
            List<GoldPrice> prices2021 = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));
            List<GoldPrice> prices2022 = await client.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13));

            prices.AddRange(prices2020);
            prices.AddRange(prices2021);
            prices.AddRange(prices2022);
            await ToXML(prices);
        }
        public async Task ToXML(List<GoldPrice> l)
        {

            XDocument doc = new XDocument(new XElement("List_of_prices",
                        from price in l
                        select new XElement("Gold",
                                    new XElement("Date", price.Date),
                                    new XElement("Price", price.Price)
                                )));

            doc.Declaration = new XDeclaration("1.0", "utf-8", "true");

            doc.Save(@"C:\\ListOfPrice.xml");

        }
        [Test]
        public async Task XMLtoConsInit()
        {
            XDocument doc = XDocument.Load("C:\\ListOfPrice.xml");
            XMLtoCons(doc);
        }

            public async Task XMLtoCons(XDocument doc)
        {
            foreach (XElement price in doc.Root.Elements())
            {
                Console.WriteLine("Date : {0}  Price : {1}",
                                    price.Element("Date").Value,
                                    price.Element("Price").Value);
            }
        }
    }
}
