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
            if(Items[i].Quality<=50){
             if(Items[i].Name=="Aged Brie"){
                UpdateBrie(Items[i]);
             }else if(Items[i].Name=="Backstage passes to a TAFKAL80ETC concert"){
                BackstagePassUpdate(Items[i]);
             }else if(Items[i].Name=="Aged Brie"){
                UpdateBrie(Items[i]);
             }else if(Items[i].Name.Contains("Conjured")){
                UpdateConjured(Items[i]);
             }else{
                UpdateNormalItem(Items[i]);
             }
            }
            }
        }

    //Quality is never negative
    //After SellInDate the Quality degrades twice as fast
    //Quality is never above 50
    
    public void UpdateLegendaryItems(Item i){
        //if Quality is above 50
        //no changes
    }

    public void UpdateBrie(Item i){
        //brie increases in quality over time
        i.SellIn--;
        if(i.SellIn >= 0 && i.Quality<=49){
            i.Quality++;
        }else{
            i.Quality+=2;
        }
        if(i.Quality>50){
            i.Quality=50;
        }
        
    }

    public void UpdateConjured(Item i){
        //Quality degrades twice as fast
        //SellInUpdateBefore or after?? O_O
        i.SellIn--;
        if(i.Quality>0){
            if(i.SellIn>=0 ){
                i.Quality-=2;
            }else{
                i.Quality-=4;
            }
        }
        if(i.Quality<0){
            i.Quality=0;
        }
    }

    public void BackstagePassUpdate(Item i){
        //Increases by 2 within 10 days of the concert
        //Increases by 3 within 5 days of the concert
        //Quality becomes 0 after SellInDate becomes -1
        i.SellIn--;
        if(i.SellIn>=0){
        if(i.SellIn<=10&&i.SellIn>5){
            i.Quality+=2;
        }
        if(i.SellIn<=5){
            i.Quality+=3;
        }
        }else{
            i.Quality=0;
        }
        if(i.Quality>50){
            i.Quality=50;
        }
    }

    public void UpdateNormalItem(Item i){
        //Degrade Quality by 1
        //reduce SellIn by 1
        i.SellIn--;
        if(i.Quality>0 && i.SellIn>=0){
            i.Quality--;
        }
        if(i.Quality>0 && i.SellIn<0){
            i.Quality-=2;
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