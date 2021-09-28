using GildedRose.Console.ItemUpdaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;

        Dictionary<string, Type> updaters;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                },
            };

            app.UpdateQuality(app.Items);

            System.Console.ReadKey();
        }

        private static Dictionary<string, Type> InitializeUpdaters()
        {
            Dictionary<string, Type> dict = new Dictionary<string, Type>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                CustomItemUpdaterAttribute attr = type.GetCustomAttribute<CustomItemUpdaterAttribute>();
                if (attr != null)
                {
                    dict.Add(attr.LinkedName, type);
                }
            }
            return dict;
        }

        public void UpdateQuality(IList<Item> items)
        {
            updaters = updaters ?? InitializeUpdaters();

            foreach (IItemUpdater updater in items.Select(GetUpdater))
            {
                updater.Update();
            }
        }

        private IItemUpdater GetUpdater(Item item)
        {
            IItemUpdater updater;
            if (updaters.TryGetValue(item.Name, out Type type))
            {
                updater = (IItemUpdater)Activator.CreateInstance(type, item);
            }
            else if (item.Name.Contains("Conjured"))
            {
                updater = new ConjuredItemUpdater(item);
            }
            else
            {
                updater = new RegularItemUpdater(item);
            }

            return updater;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
