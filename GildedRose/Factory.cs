namespace GildedRose;

public static class Factory
{

    public static Program createProgram()
    {
        return new Program();
    }

    public static IItem createItem()
    {
        return new Item();
    }

    public static IList<IItem> createList()
    {
        return new List<IItem>();
    }
}