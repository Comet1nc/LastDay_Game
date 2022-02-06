using System;
using MainGameFiles.Scripts.Interfaces;

namespace MainGameFiles.Scripts.Inventory.InventoryItems
{
    public class Rock : IInventoryItem
    {
        public Type type => GetType();

        public IInventoryItemState state { get; }
        public IInventoryItemInfo info { get; }


        public Rock(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedRock = new Rock(info);
            clonedRock.state.amount = state.amount;
            return clonedRock;
        }
    }
}
