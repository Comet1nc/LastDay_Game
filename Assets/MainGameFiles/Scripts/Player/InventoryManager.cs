using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _pistolInfo;
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;
    [SerializeField] private List<InventoryItemInfo> _itemsInfo;
    [SerializeField] private GameObject _panel;

    public InventoryWithSlots inventory => playerInventory.inventory;

    public UIPlayerInventory playerInventory;

    void Awake()
    {
        var uiSlots = _panel.GetComponentsInChildren<UIInventorySlot>();
        playerInventory = new UIPlayerInventory(_appleInfo, _pepperInfo, uiSlots, _itemsInfo, _pistolInfo);
        playerInventory.FillSlots();
    }

   
}
