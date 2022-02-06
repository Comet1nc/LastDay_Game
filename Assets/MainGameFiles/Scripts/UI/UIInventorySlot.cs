using MainGameFiles.Scripts.Interfaces;
using MainGameFiles.Scripts.Inventory;
using MainGameFiles.Scripts.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainGameFiles.Scripts.UI
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] protected UIInventoryItem _uiInventoryItem;
        [SerializeField] protected InventoryManager _inventoryManager;
        [SerializeField] protected bool _gunSlot;

        public IInventorySlot slot { get; protected set; }

        protected UIPlayerInventory _uiInventory;
        protected InventoryWithSlots _inventory;

        private void Start()
        {
            _uiInventory = _inventoryManager.playerInventory;
        
        }

        public virtual void SetSlot(IInventorySlot newSlot)
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

        public virtual void Refresh()
        {
            if (slot != null)
                _uiInventoryItem?.Refresh(slot);
        }
    }
}
