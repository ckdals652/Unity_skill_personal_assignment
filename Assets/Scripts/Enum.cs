using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    public enum EnumLayer
    {
        Defalt,
        TransParentFX,
        IgnoreRaycast,
        Enemy,
        Water,
        UI,
        Player,
        Ground
    }

    public enum EnumItemType
    {
        Consumable,
        Structure
    }
    
    public enum ConsumableType
    {
        Hunger,
        Health
    }
}
