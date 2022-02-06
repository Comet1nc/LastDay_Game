using System;
using MainGameFiles.Scripts.Interfaces;

namespace MainGameFiles.Scripts.Inventory
{
    [Serializable]
    public class InventoryItemState : IInventoryItemState
    {
        public int itemAmount;
        public bool isItemEquipped;

        public int amount { get => itemAmount; set => itemAmount = value; }
        public bool IsEquipped { get => isItemEquipped; set => isItemEquipped = value; }

        public InventoryItemState()
        {
            itemAmount = 0;
            isItemEquipped = false;
        }
        public InventoryItemState(int itemAmount, bool isItemEquipped = false)
        {
            this.itemAmount = itemAmount;
            this.isItemEquipped = isItemEquipped;
        }
    }
}
