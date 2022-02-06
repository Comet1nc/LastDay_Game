using System;
using System.Collections;
using UnityEngine;

namespace MainGameFiles.Scripts.Interfaces
{
    public interface IInventorySlot
    {
        SlotType slotType { get; set; }
        bool isGunSlot { get; set; }
        bool isFull { get; }
        bool isEmpty { get; }

        IInventoryItem item { get; }
        Type itemType { get; }
        int amount { get; }
        int capacity { get; }

        void SetItem(IInventoryItem item);
        void Clear();
    }

    public enum SlotType // Уникальные обьекты которые не стакаются. // NEVER CHANGE, because this broke inventory !!!!
    {
        Default,
        Gun,
        Backpack,
        Hat, // Головной убор
        Shirt, // Верхняя одежда
        Jeans, // Любые штаны
        Boots // Любые ботинки
    }
}