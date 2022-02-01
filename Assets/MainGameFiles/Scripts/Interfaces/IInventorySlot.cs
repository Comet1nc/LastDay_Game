using System.Collections;
using System;
using UnityEngine;

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

public enum SlotType // ���������� ������� ������� �� ���������. // NEVER CHANGE, because this broke inventory !!!!
{
    Default,
    Gun,
    Backpack,
    Hat, // �������� ����
    Shirt, // ������� ������
    Jeans, // ����� �����
    Boots // ����� �������
}
