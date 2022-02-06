using MainGameFiles.Scripts.Interfaces;
using System;

namespace MainGameFiles.Scripts.Inventory.InventoryItems
{
    public class TreeItem : IInventoryItem

    {
        public Type type => GetType();

        public IInventoryItemState state { get; }
        public IInventoryItemInfo info { get; }


        public TreeItem(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }
        public TreeItem(IInventoryItemInfo info, IInventoryItemState state)
        {
            this.info = info;
            this.state = state;
        }

        public IInventoryItem Clone()
        {
            var clonedRock = new TreeItem(info);
            clonedRock.state.amount = state.amount;
            return clonedRock;
        }

    }
}