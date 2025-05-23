using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDataConsumable
{
    public Enum.ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")] public string displayName;
    public string description;
    public Enum.EnumItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")] public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")] public ItemDataConsumable[] consumables;
}