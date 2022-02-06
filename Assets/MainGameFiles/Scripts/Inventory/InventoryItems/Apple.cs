using System;
using MainGameFiles.Scripts.Interfaces;

namespace MainGameFiles.Scripts.Inventory.InventoryItems
{
    public class Apple : IInventoryItem
    {
        public Type type => GetType();

        public IInventoryItemState state { get; }
        public IInventoryItemInfo info { get; }
    

        public Apple(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedApple = new Apple(info);
            clonedApple.state.amount = state.amount;
            return clonedApple;
        }
    }
}

