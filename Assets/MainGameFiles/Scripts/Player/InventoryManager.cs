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
    [SerializeField] private GameObject _chestPanel;

    private int _capacity = 21;
    private UIInventoryEquipmentSlot[] _uiEquipmentSlots;

    private ChestManager _chest;

    public ChestManager chest { get => _chest; set => _chest = value; }
    public InventoryWithSlots inventory => playerInventory.inventory;
    public UIPlayerInventory playerInventory;

    void Awake()
    {
        var uiSlots = _panel.GetComponentsInChildren<UIInventorySlot>();
        playerInventory = new UIPlayerInventory(_appleInfo, _pepperInfo, uiSlots, _capacity, _pistolInfo);
        playerInventory.FillSlots();
        _uiEquipmentSlots = _panel.GetComponentsInChildren<UIInventoryEquipmentSlot>();
    }

    public void OpenedChest(ChestManager chest)
    {
        _chest = chest;
        TurnOffOrOnEquipmentSlots(false); // Закрываем слоты экипировки
        TurnOffOrOnChestPanel(true); // Открываем слоты сундука
    }

    public void TurnOffOrOnChestPanel(bool turnOn)
    {
        _chestPanel.SetActive(turnOn);
    }

    public void TurnOffOrOnEquipmentSlots(bool turnOn)
    {
        foreach (var slot in _uiEquipmentSlots)
        {
            slot.gameObject.SetActive(turnOn);
        }
    }
}
