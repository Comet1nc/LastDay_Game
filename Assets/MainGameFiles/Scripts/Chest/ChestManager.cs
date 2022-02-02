using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour, IUseable
{
    [SerializeField] private InventoryManager _playerInventoryManager;
    [SerializeField] private UICanvasControllerInput _UIController;
    [SerializeField] private InventoryItemInfo _pistolInfo;
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;
    [SerializeField] private List<InventoryItemInfo> _itemsInfo;
    [SerializeField] private GameObject _panel;

    private int _capacity = 20;

    public InventoryWithSlots inventory => playerInventory.inventory;

    public UIPlayerInventory playerInventory;

    void Awake()
    {
        var uiSlots = _panel.GetComponentsInChildren<UIInventorySlot>();
        playerInventory = new UIPlayerInventory(_appleInfo, _pepperInfo, uiSlots, _capacity, _pistolInfo);
        playerInventory.FillSlots();
    }

    public void Use()
    {
        OpenChest();
    }

    private void OpenChest()
    {
        _UIController.OpenInventory();
        _playerInventoryManager.OpenedChest(this);
        playerInventory.SetupInventoryUI(inventory);
        Debug.Log("OPEN CHEST");
    }
}
