using MainGameFiles.Scripts.Player;
using UnityEngine;

namespace MainGameFiles.Scripts.CanvasInputs
{
    public class UIInventoryClose : MonoBehaviour
    {
        [SerializeField] private InventoryManager _inventoryManager;
        [SerializeField] private Camera _inventoryCamera;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private Canvas _mainVirtualController;

        private void Start()
        {
            _inventoryCanvas.enabled = false;
        }

        public void CloseInventory()
        {
            if(_inventoryManager.chest == null)
            {
                _inventoryCamera.gameObject.SetActive(false);
                _mainVirtualController.enabled = true;
                _inventoryCanvas.enabled = false;
            }
            else
            {
                _inventoryManager.TurnOffOrOnEquipmentSlots(true);
                _inventoryManager.TurnOffOrOnChestPanel(false);
                _inventoryManager.chest = null;
                _inventoryCamera.gameObject.SetActive(false);
                _mainVirtualController.enabled = true;
                _inventoryCanvas.enabled = false;
            }
        
        }
    }
}
