using System.Collections.Generic;
using MainGameFiles.Scripts.CanvasInputs;
using MainGameFiles.Scripts.Interfaces;
using MainGameFiles.Scripts.Inventory;
using MainGameFiles.Scripts.Player;
using MainGameFiles.Scripts.UI;
using UnityEngine;

namespace MainGameFiles.Scripts.Chest
{
    public class ChestManager : MonoBehaviour, IUseable
    {
        [SerializeField] private InventoryManager _playerInventoryManager;
        [SerializeField] private UICanvasControllerInput _UIController;
        [SerializeField] private InventoryItemInfo _pistolInfo;
        [SerializeField] private InventoryItemInfo _appleInfo;
        [SerializeField] private InventoryItemInfo _pepperInfo;
        [SerializeField] private List<InventoryItemInfo> _itemsInfo;
        [SerializeField] private GameObject _panel;

        private const int Capacity = 20;

        public InventoryWithSlots inventory => playerInventory.inventory;

        public UIPlayerInventory playerInventory { get; set; }

        void Awake()
        {
            var uiSlots = _panel.GetComponentsInChildren<UIInventorySlot>();
            playerInventory = new UIPlayerInventory(_appleInfo, _pepperInfo, uiSlots, Capacity, _pistolInfo);
            playerInventory.FillSlots();
        }

        public void Use()
        {
            OpenChest();
        }

        private void OpenChest()
        {
            _UIController.OpenInventory();
            _playerInventoryManager.OpenedChest(this);
            playerInventory.SetupInventoryUI(inventory);
        }
    }
}
