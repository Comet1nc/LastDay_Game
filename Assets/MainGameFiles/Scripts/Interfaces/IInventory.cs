using System.Collections;
using System;
using UnityEngine;

public interface IInventory
{
    int capacity { get; }
    bool isFull { get; }

    IInventoryItem GetItem(Type itemType);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItems(Type itemType);
    IInventoryItem[] GetEquippedItems();
    int GetItemAmount(Type itemType);

    bool TryAdd(object sender, IInventoryItem item);
    void Remove(object sender, Type itemType, int amount = 1);
    bool HasItem(Type type, out IInventoryItem item);
}
