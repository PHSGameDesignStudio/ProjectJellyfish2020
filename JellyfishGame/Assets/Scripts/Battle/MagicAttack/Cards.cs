using UnityEngine;
public class Cards
{
    public static Card thunderstorm = new Card()
    {
        MinigameResourceName = "Magic/PlayerMagicAttack1",
        name = "Thunderstorm",
        description = "Summon a thunderstorm targeting your enemy",
        DmgHp = 5,
        DmgAnimResourceName = "ThunderstormAnim",
    };
    public static Card acidicrainshower = new Card()
    {
        MinigameResourceName = "Magic/PlayerMagicAttack1",
        name = "Rain Shower",
        description = "Shower acidic rain onto your enemy",
        DmgHp = 2,
        DmgAnimResourceName = "RainShowerAnim",
    };
}
