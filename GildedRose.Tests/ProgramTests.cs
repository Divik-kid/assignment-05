namespace GildedRose.Tests;
using GildedRose;
public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

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

}