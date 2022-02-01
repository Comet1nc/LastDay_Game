using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem _uiInventoryItem;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private bool _gunSlot;

    public IInventorySlot slot { get; private set; }

    private UIPlayerInventory _uiInventory;
    private InventoryWithSlots _inventory;

    private void Start()
    {
        _uiInventory = _inventoryManager.playerInventory;
        
    }

    public void SetSlot(IInventorySlot newSlot)
    {
        slot = newSlot;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        _inventory = _inventoryManager.inventory;
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherSlotUI.slot;
        var inventory = _inventory;

        if(otherSlot == slot)
        {
            return;
        }
        inventory.TransitFromSlotToSlot(this, otherSlot, slot);

        Refresh();
        otherSlotUI.Refresh();
    }

    public void Refresh()
    {
        if (slot != null)
            _uiInventoryItem?.Refresh(slot);
    }
}
