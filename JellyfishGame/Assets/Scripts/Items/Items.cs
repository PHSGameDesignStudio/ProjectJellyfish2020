using UnityEngine;
public class Items
{
    public static IItem sword = new IItem() {
        Name = "Sword",
        Description =
            "It's a sword, a basic swinging weapon with 4 max attack Damage. " +
            "What more info do you need to know about a sword?!"
        ,
        imageResourcePath = "Sprites/Items/sword",
        Type = "AttackDmg",
        booster_attackDmg = 4,
        
        
    };

    public static IItem trident = new IItem()
    {
        Name = "Trident",
        Description =
            "The ultimate weapon of the waters shaped like a sharp fork, Deals 6 max Damage. " +
            "The only reason you got it is because you were a jerk that killed someone."
        ,
        imageResourcePath = "Sprites/Items/trident",
        Type = "AttackDmg",
        booster_attackDmg = 6,
    };

    public static IItem sushi = new IItem()
    {
        Name = "Trident",
        Description =
            "Ooh sushi, maybe it was teleported from your local seafood store." +
            "Heals 5 hp"
        ,
        imageResourcePath = "Sprites/Items/sushi",
        Type = "Consumable",
        booster_hp = 5,
    };

    public static IItem map = new IItem()
    {
        Name = "Trident",
        Description =
            "I'm the map, I'm the map, I'm da map...." +
            "Jokes aside this allows you to see where you are in this vast world."
        ,
        imageResourcePath = "Sprites/Items/map",
        Type = "Map",
    };
}
