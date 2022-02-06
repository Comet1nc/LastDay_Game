using System;
using MainGameFiles.Scripts.Interfaces;

namespace MainGameFiles.Scripts.Inventory.InventoryItems
{
    public class Pepper : IInventoryItem
    {
        public Type type => GetType();

        public IInventoryItemState state { get; }
        public IInventoryItemInfo info { get; }

        public Pepper(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedPepper = new Pepper(info);
            clonedPepper.state.amount = state.amount;
            return clonedPepper;
        }
    }
}
