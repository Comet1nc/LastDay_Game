namespace MainGameFiles.Scripts.Interfaces
{
    public interface IInventoryItemState
    {
        int amount { get; set; }
        bool IsEquipped { get; set; }
    }
}
