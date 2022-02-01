using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItemInfo
{
    string id { get; }
    string title { get; }
    string desctiption { get; }
    int maxItemsInInventorySlot { get; }
    Sprite spriteIcon { get; }
    GameObject prefab { get; }
    ItemType itemType { get; }

}

public enum ItemType // NEVER CHANGE
{
    Default,
    Gun,
    Backpack,
    Hat, // Головной убор
    Shirt, // Верхняя одежда
    Jeans, // Любые штаны
    Boots // Любые ботинки
}