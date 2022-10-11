using System;
using System.Collections.Generic;

namespace GildedRose
{
  public class Program
    {
        IList<Item> Items;
        static void Main(string[] args){}
        public void UpdateQuality(IList<Item> Items)
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
    {   public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

}