using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryClose : MonoBehaviour
{
    [SerializeField] private Camera _inventoryCamera;
    [SerializeField] private Canvas _inventoryCanvas;
    [SerializeField] private Canvas _mainVirtualController;

    public void CloseInventory()
    {
        _inventoryCamera.gameObject.SetActive(false);
        _mainVirtualController.enabled = true;
        _inventoryCanvas.enabled = false;
    }
}
