using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipper : MonoBehaviour
{
    [SerializeField] private Transform _gunParent;
    [SerializeField] private InventoryManager _inventoryManager;

    private IInventoryItem _gun;
    private GameObject _gunPrefab;
    private GameObject _instantiatedGun;

    private void Start()
    {
        _inventoryManager.inventory.OnItemEquipEvent += EquipOrDeEquipGun;
    }

    private void OnDisable()
    {
        _inventoryManager.inventory.OnItemEquipEvent -= EquipOrDeEquipGun;
    }

    public void EquipOrDeEquipGun(IInventoryItem gun, bool EquipState)
    {
        if(EquipState)
        {
            gun.state.IsEquipped = false;
            Destroy(_instantiatedGun);
            return;
        }

        _gun = gun;
        _gun.state.IsEquipped = true;
        _gunPrefab = gun.info.prefab;
        _instantiatedGun = Instantiate(gun.info.prefab, _gunParent);
        _instantiatedGun.transform.localPosition = new Vector3(0.024f, -0.1f, -0.014f);
        _instantiatedGun.transform.localRotation = Quaternion.Euler(70.73f, -35.835f, 133.238f);
    }
}
