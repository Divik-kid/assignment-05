namespace GildedRose.Tests;
using GildedRose;
public class ProgramTests
{

    [Fact]
    public void Test_Item_Quality_SellPrice_Name()
    {
        var i1 = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        i1.Quality.Should().Be(20);
    }

    [Fact]
    public void Test_UpdateQuality()
    {
        
        var items = new List<Item>(){
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 },
        new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 },
        new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        });
        
    }

    [Fact]
    public void Test_Negative_SellIn()
    {
        
        var items = new List<Item>(){ new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 }};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item { Name = "+5 Dexterity Vest", SellIn = -2, Quality = 18 }
        });
    }
    
    [Fact]
        public void Test_Backstage_concert_sell_below_11()
    {
        var items = new List<Item>(){ new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20}};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 22}});
    }

    [Fact]
    public void Test_Backstage_concert_sell_below_6()
    {
        var items = new List<Item>(){ new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20}};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 23}});
    }

        [Fact]
    public void Test_Brie_SellIn_Below_0()
    {
        var items = new List<Item>(){ new Item { Name = "Aged Brie", SellIn = -2, Quality = 0 }};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item { Name = "Aged Brie", SellIn = -3, Quality = 2 }});
    }

        [Fact]
    public void Test_Backstage_concert_sell_below_0()
    {
        var items = new List<Item>(){ new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 20}};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 0}});
    }

    [Fact]
    public void Test_sulfuras_sell_below_0()
    {
        var items = new List<Item>(){ new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }};
        var app = new Program();
        app.UpdateQuality(items);

        items.Should().BeEquivalentTo(new List<Item>(){ new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }});
    }



}