using System;

namespace MainGameFiles.Scripts.Interfaces
{
    public interface IInventoryItem
    {
        IInventoryItemState state { get; }
        IInventoryItemInfo info { get; }

        Type type { get; }
    
        IInventoryItem Clone();
    }
}


