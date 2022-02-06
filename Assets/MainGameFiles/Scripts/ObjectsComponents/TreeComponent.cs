using MainGameFiles.Scripts.Interfaces;
using MainGameFiles.Scripts.Inventory;
using MainGameFiles.Scripts.Inventory.InventoryItems;
using MainGameFiles.Scripts.Player;
using UnityEngine;

namespace MainGameFiles.Scripts.ObjectsComponents
{
    public class TreeComponent : MonoBehaviour, IHitable
    {
        [SerializeField] private InventoryItemInfo _info;
        [SerializeField] private InventoryManager _inventory;
        [SerializeField] private int _startHealth;

        public int _currentHealth;
        private ColliderHandler _collider;
        private TreeItem _tree;

        private void Awake()
        {
            _collider = _inventory.gameObject.GetComponent<ColliderHandler>();
        }
        private void OnEnable()
        {
            var treeState = new InventoryItemState(5);
            _tree = new TreeItem(_info, treeState);
            _currentHealth = _startHealth;
        }
        public void Hit(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_inventory.inventory.TryAdd(this, _tree))
            {
                gameObject.SetActive(false);
                _collider.EnabledAttackButton(false);
                _collider.UnSet(this);
            }
        }
    }
}
