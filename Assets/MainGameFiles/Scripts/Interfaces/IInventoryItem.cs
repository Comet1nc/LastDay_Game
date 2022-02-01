using System.Collections;
using System;
using UnityEngine;

public interface IInventoryItem
{
    IInventoryItemState state { get; }
    IInventoryItemInfo info { get; }

    Type type { get; }
    
    IInventoryItem Clone();
}


