using MainGameFiles.InputSystem;
using UnityEngine;

namespace MainGameFiles.Scripts.CanvasInputs
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        [SerializeField] private Camera _inventoryCamera;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private Canvas _mainVirtualController;

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }

        public void OpenInventory()
        {
            _inventoryCamera.gameObject.SetActive(true);
            _inventoryCanvas.enabled = true;
            _mainVirtualController.enabled = false;
        }
        
    }
}


