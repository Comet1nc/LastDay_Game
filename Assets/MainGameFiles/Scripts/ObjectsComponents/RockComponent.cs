using MainGameFiles.Scripts.Interfaces;
using MainGameFiles.Scripts.Inventory;
using MainGameFiles.Scripts.Inventory.InventoryItems;
using MainGameFiles.Scripts.Player;
using UnityEngine;

namespace MainGameFiles.Scripts.ObjectsComponents
{
    public class RockComponent : MonoBehaviour, IPickable
    {
        [SerializeField] private InventoryItemInfo _info;
        [SerializeField] private InventoryManager _inventory;

        private ColliderHandler _collider;
        private Rock _rock;

        private void Awake()
        {
            _collider = _inventory.gameObject.GetComponent<ColliderHandler>();
        }

        public void Pick()
        {
            if (_inventory.inventory.TryAdd(this, _rock))
            {
                gameObject.SetActive(false);
                _collider.EnabledUseButton(false);
                _collider.UnSet(this);
            }
        }

        private void OnEnable()
        {
            _rock = new Rock(_info);
        }
    }
}
