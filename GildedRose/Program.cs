using System;
using System.Collections.Generic;

namespace GildedRose
{
  public class Program
    {
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
                        UpdateQuality(Items[i]); 
                    break;
                }
            }
        }

        public void UpdateLegendaryQuality(Item item) {
            // a legendary item, never has to be sold or decreases in Quality
        }

        public void UpdateAgedQuality(Item item) {
            UpdateQuality(item, 1);
        }

        public void UpdateTicketsQuality(Item item) {
            int qualityDecreaseRate = 1;
            if(item.SellIn < 11) {
                qualityDecreaseRate += 1;
            }
            if(item.SellIn < 6) {
                qualityDecreaseRate += 1;
            }
            UpdateQuality(item, qualityDecreaseRate);
            if(item.SellIn < 0) {
                item.Quality = 0;
            }
        }
        public void UpdateConjuredQuality(Item item) {
            UpdateQuality(item, -2);
        }

        public void UpdateQuality(Item item, int qualityDecreaseRate = -1) {
            // DayPassing
            item.SellIn -= 1;
            // Once the sell by date has passed, Quality degrades twice as fast
            if(item.SellIn >= 0) {
                item.Quality += qualityDecreaseRate;
            } else {
                item.Quality += qualityDecreaseRate*2;
            }
            KeepBounds(item);
        }

        private void KeepBounds(Item item) {
            // The Quality of an item is never negative and is nevere more than 50
            if(item.Quality > 50){
                item.Quality = 50;
            }
            else if(item.Quality < 0) {
                item.Quality = 0;
            } 
        }

    }

    public class Item
    {   public string? Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

}