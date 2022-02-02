using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryWithSlots : IInventory
{
    public int capacity { get; private set; }

    public bool isFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots;
    //private IInventorySlot _gunSlot;

    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;
    public event Action<object> OnInventoryStateChangedEvent;
    public event Action<IInventoryItem, bool> OnItemEquipEvent;

    public InventoryWithSlots(int capacity)
    {
        this.capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);

        for (int i = 0; i < capacity; i++)
        {
               _slots.Add(new InventorySlot());
        }

        if(capacity >= 21)
        {
            _slots[20].slotType = SlotType.Gun; // 21 слот в иерархиии юнити (внизу)
        }
        
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
            {
                allItems.Add(slot.item);
            }
        }
        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();

        var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);

        foreach (var slot in slotsOfType)
        {
            allItemsOfType.Add(slot.item);
        }
        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        throw new NotImplementedException();
    }

    public IInventoryItem GetItem(Type itemType)
    {
         return _slots.Find(slot => slot.itemType == itemType).item;
    }

    public int GetItemAmount(Type itemType)
    {
        int amount = 0;

        var allItemSlots = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);

        foreach(var slot in allItemSlots)
        {
            amount += slot.amount;
        }

        return amount;
    }

    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }

    public bool TryAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.Find(slot => !slot.isEmpty && slot.itemType == item.type && !slot.isFull);

        if (slotWithSameItemButNotEmpty != null)
            return TryAddToSlot(sender, slotWithSameItemButNotEmpty, item);

        var emptySlot = _slots.Find(slot => slot.isEmpty);

        if (emptySlot != null)
            return TryAddToSlot(sender, emptySlot, item);

        return false;
    }

    public bool TryAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.state.amount <= item.info.maxItemsInInventorySlot;

        var amountToAdd = fits ? item.state.amount : item.info.maxItemsInInventorySlot - slot.amount;
        var amountLeft = item.state.amount - amountToAdd;

        var clonedItem = item.Clone();
        clonedItem.state.amount = amountToAdd;

        if (slot.isEmpty)
            slot.SetItem(clonedItem);
        else
            slot.item.state.amount += amountToAdd;
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangedEvent?.Invoke(sender);

        if (amountLeft <= 0)
            return true;

        item.state.amount = amountLeft;
        return TryAdd(sender, item);
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)
            return;

        var amountToRemove = amount;
        var count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];

            if(slot.amount >= amountToRemove)
            {
                slot.item.state.amount -= amountToRemove;
                if (slot.amount == 0)
                    slot.Clear();

                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
                OnInventoryStateChangedEvent?.Invoke(sender);

                break;
            }

            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount;
            slot.Clear();

            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountRemoved);
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
    }

    private void EquipOrDeEquipGun(object sender, IInventorySlot fromSlot, IInventorySlot toSlot, bool EquipState)
    {
        OnItemEquipEvent?.Invoke(fromSlot.item, EquipState);
        toSlot.SetItem(fromSlot.item);
        fromSlot.Clear();
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public void TransitFromSlotToEquipmentSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.isEmpty)
            return;
        if (toSlot.isFull)
            return;
        if (fromSlot.item.info.itemType == ItemType.Default)
            return;

        if (toSlot.isEmpty)
        {
            if (toSlot.slotType != SlotType.Default)
            {
                // экипировка оружие в оружейный слот
                if (fromSlot.item.info.itemType == ItemType.Gun && toSlot.slotType == SlotType.Gun)
                {
                    EquipOrDeEquipGun(sender, fromSlot, toSlot, fromSlot.item.state.IsEquipped);
                    return;
                }

                // попытка экипировать не оружие, в оружейный слот
                //if (fromSlot.item.info.itemType != ItemType.Gun && toSlot.slotType == SlotType.Gun)
                //return;
                if (((int)fromSlot.item.info.itemType) != ((int)toSlot.slotType))
                    return;

            }
        }

        {
            /*if (toSlot.isEmpty) todo: Реализация экипирования оставшихся видов предметов
                    {
                        if (toSlot.slotType != SlotType.Default)
                        {
                            if (fromSlot.item.info.itemType == ItemType.Default)
                                return;

                            // экипировка уникального предмета в такой же уникальный слот
                            if (((int)fromSlot.item.info.itemType) == ((int)toSlot.slotType))
                            {
                                //Equip
                                return;
                            }

                            // попытка экипировать не оружие, в оружейный слот
                            if (((int)fromSlot.item.info.itemType) != ((int)toSlot.slotType))
                                return;
                        }

                        // Снять экипированный предмет
                        if (fromSlot.item.info.itemType != ItemType.Default && fromSlot.item.state.IsEquipped)
                        {
                            //DeEquip
                            return;
                        }
                    }*/
        } // Альтернативная реализация сравнение, с помощью enum

    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.isEmpty)
            return;
        if (toSlot.isFull)
            return;

        // Снять экипированое оружие
        if (fromSlot.item.info.itemType == ItemType.Gun && fromSlot.item.state.IsEquipped)
        {
            if (!toSlot.isEmpty)
                return;
            EquipOrDeEquipGun(sender, fromSlot, toSlot, fromSlot.item.state.IsEquipped);
            return;
        }

        if (!toSlot.isEmpty && fromSlot.itemType != toSlot.itemType)
            return;

        var slotCapacity = fromSlot.capacity;
        var fits = fromSlot.amount + toSlot.amount <= slotCapacity;
        var amountToAdd = fits ? fromSlot.amount : slotCapacity - toSlot.amount;
        var amountLeft = fromSlot.amount - amountToAdd;

        if(toSlot.isEmpty)
        {
            toSlot.SetItem(fromSlot.item);
            fromSlot.Clear();
            OnInventoryStateChangedEvent?.Invoke(sender);
        }

        toSlot.item.state.amount += amountToAdd;
        if (fits)
            fromSlot.Clear();
        else
            fromSlot.item.state.amount = amountLeft;
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }
}
