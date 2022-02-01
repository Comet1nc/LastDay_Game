using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Gameplay/Items/Create New ItemInfo")]
public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _desctiption;
    [SerializeField] private int _maxItemsInInventorySlot;
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private ItemEquipper _itemEquipper;

    public string id => _id;
    public string title => _title;
    public string desctiption => _desctiption;
    public int maxItemsInInventorySlot => _maxItemsInInventorySlot;
    public Sprite spriteIcon => _spriteIcon;
    public GameObject prefab => _prefab;
    public ItemType itemType => _itemType;
    public ItemEquipper itemEquipper => _itemEquipper;
}
