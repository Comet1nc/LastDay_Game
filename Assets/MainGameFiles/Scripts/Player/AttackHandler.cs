using MainGameFiles.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace MainGameFiles.Scripts.Player
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private Button _attackButton;

        private PlayerStats _playerStats;
        private IAttackable _objectThatCanAttack;
        private IHitable _objectThatHit;
    
        public Button attackButton => _attackButton;
        public IAttackable objectThatCanAttack { get => _objectThatCanAttack; set => _objectThatCanAttack = value; }
        public IHitable objectThatHit { get => _objectThatHit; set => _objectThatHit = value; }

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
        }

        private void Start()
        {
            _attackButton.interactable = false;
        }

        public void Click()
        {
            if (_objectThatCanAttack != null)
            {
                _objectThatCanAttack.Attack(_playerStats.damage);
            }
            if (_objectThatHit != null)
            {
                _objectThatHit.Hit(_playerStats.damage);
            }

        }
    }
}
