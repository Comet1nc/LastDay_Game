using MainGameFiles.Scripts.Interfaces;
using UnityEngine.EventSystems;

namespace MainGameFiles.Scripts.UI
{
    public class UIInventoryEquipmentSlot : UIInventorySlot
    {
        private void Start()
        {
            _uiInventory = _inventoryManager.playerInventory;
        }

        public override void SetSlot(IInventorySlot newSlot)
        {
            slot = newSlot;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            bool otherSlotIsEquipment = false;
            _inventory = _inventoryManager.inventory;
            var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            var otherSlotUI = otherItemUI?.GetComponentInParent<UIInventorySlot>();
            if(otherSlotUI == null)
            {
                otherItemUI?.GetComponentInParent<UIInventoryEquipmentSlot>();
                otherSlotIsEquipment = true;
            }
            
            var otherSlot = otherSlotUI.slot;
            var inventory = _inventory;

            if (otherSlot == slot)
                return;

            if(!otherSlotIsEquipment)
            {
                inventory.TransitFromSlotToEquipmentSlot(this, otherSlot, slot);
            }

            Refresh();
            otherSlotUI.Refresh();
        }

        public override void Refresh()
        {
            if (slot != null)
                _uiInventoryItem?.Refresh(slot);
        }
    }
}
