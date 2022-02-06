using System.Collections.Generic;
using MainGameFiles.Scripts.Interfaces;
using MainGameFiles.Scripts.Inventory;
using MainGameFiles.Scripts.Inventory.InventoryItems;

namespace MainGameFiles.Scripts.UI
{
    public class UIPlayerInventory
    {
        private InventoryItemInfo _pistolInfo;
        private InventoryItemInfo _appleInfo;
        private InventoryItemInfo _pepperInfo;
        private int _capacity;

        private UIInventorySlot[] _uiSlots;

        public InventoryWithSlots inventory { get; }
        public UIInventorySlot[] uiSlots => _uiSlots;
        public bool isChest => !(_capacity >= 21);

        public UIPlayerInventory(InventoryItemInfo appleInfo, InventoryItemInfo peppeInfo, UIInventorySlot[] uiSlots, int capacity, InventoryItemInfo pistolInfo)
        {
            _pistolInfo = pistolInfo;
            _appleInfo = appleInfo;
            _pepperInfo = peppeInfo;
            _uiSlots = uiSlots;
            _capacity = capacity;

            inventory = new InventoryWithSlots(capacity);
            inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;

        }

        public void FillSlots()
        {
            var allSlots = inventory.GetAllSlots();

        
        
            var apple1 = new Apple(_appleInfo);
            apple1.state.amount = 4; 
            inventory.TryAddToSlot(this, allSlots[0], apple1);

            var apple2 = new Apple(_appleInfo);
            apple2.state.amount = 5;
            inventory.TryAddToSlot(this, allSlots[1], apple2);

            var pistol = new Pistol(_pistolInfo);
            pistol.state.amount = 1;
            inventory.TryAddToSlot(this, allSlots[5], pistol);

            /*
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;
        for (int i = 0; i < filledSlots; i++)
        {
            var filledSlot = RandomFill1(availableSlots);
            availableSlots.Remove(filledSlot);

            filledSlot = RandomFill2(availableSlots);
            availableSlots.Remove(filledSlot);
        }*/

            if (isChest)
                return;
            SetupInventoryUI(inventory);
        }

        private IInventorySlot RandomFill1(List<IInventorySlot> slots)
        {
            var rSlotIndex = UnityEngine.Random.Range(0, slots.Count);
            var rSlot = slots[rSlotIndex];
            var rCount = UnityEngine.Random.Range(1, 4);
            var apple = new Apple(_appleInfo);
            apple.state.amount = rCount;
            inventory.TryAddToSlot(this, rSlot, apple);
            return rSlot;
        }

        private IInventorySlot RandomFill2(List<IInventorySlot> slots)
        {
            var rSlotIndex = UnityEngine.Random.Range(0, slots.Count);
            var rSlot = slots[rSlotIndex];
            var rCount = UnityEngine.Random.Range(1, 4);
            var pepper = new Pepper(_pepperInfo);
            pepper.state.amount = rCount;
            inventory.TryAddToSlot(this, rSlot, pepper);
            return rSlot;
        }

        public void SetupInventoryUI(InventoryWithSlots inventory)
        {
            var allSlots = inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;
            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }


        public void OnInventoryStateChanged(object sender)
        {   
            foreach (var uiSlot in _uiSlots)
            {
                uiSlot.Refresh();
            }
        }
    }
}
