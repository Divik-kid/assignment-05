using System;
using System.Collections.Generic;

namespace GildedRose
{
    class Program
    {
        IList<Item> Items;
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
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

                          };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch(Items[i].Name) {
                    case "Sulfuras, Hand of Ragnaros":
                        UpdateLegendaryQuality(Items[i]);
                    break;
                    case "Aged Brie":
                        UpdateAgedQuality(Items[i]);
                    break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateTicketsQuality(Items[i]);
                    break;
                    case "Conjured Mana Cake":
                        UpdateConjuredQuality(Items[i]);
                    break;
                    default:
                        UpdateDefaultQuality(Items[i]); 
                    break;
                }
            }
        }

        public void UpdateLegendaryQuality(Item item) {
            // a legendary item, never has to be sold or decreases in Quality
        }

        public void UpdateAgedQuality(Item item) {
            UpdateDefaultQuality(item, 1);
        }

        public void UpdateTicketsQuality(Item item) {
            item.SellIn -= 1;
            int qualityDecreaseRate = 1;
            if(item.SellIn < 11) {
                qualityDecreaseRate += 1;
            }
            if(item.SellIn < 6) {
                qualityDecreaseRate += 1;
            }
            if(item.SellIn < 0) {
                item.Quality = 0;
                return;
            }
            item.Quality -= qualityDecreaseRate;
        }
        public void UpdateConjuredQuality(Item item) {
            UpdateDefaultQuality(item, -2);
        }

        public void UpdateDefaultQuality(Item item, int qualityDecreaseRate = -1) {
            // DayPassing
            item.SellIn -= 1;
            // The Quality of an item is never more than 50
            if(item.Quality < 50) {
                // Once the sell by date has passed, Quality degrades twice as fast
                if(item.SellIn >= 0) {
                    item.Quality += qualityDecreaseRate;
                } else {
                    item.Quality += qualityDecreaseRate*2;
                }
            } else {
                item.Quality = 50;
            }
            // The Quality of an item is never negative
            if(item.Quality < 0) {
                item.Quality = 0;
            } 
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}