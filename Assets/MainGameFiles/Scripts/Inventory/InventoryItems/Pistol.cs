using System;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IInventoryItem
{
    public Type type => GetType();

    public IInventoryItemState state { get; }
    public IInventoryItemInfo info { get; }

    public Pistol(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedPistol = new Pistol(info);
        clonedPistol.state.amount = state.amount;
        return clonedPistol;
    }
}
