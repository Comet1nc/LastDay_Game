using MainGameFiles.Scripts.Interfaces;
using UnityEngine;

namespace MainGameFiles.Scripts.Player
{
    public class ColliderHandler : MonoBehaviour
    {
        private UseHandler _useHandler;
        private AttackHandler _attackHandler;

        private void Start()
        {
            _useHandler = GetComponent<UseHandler>();
            _attackHandler = GetComponent<AttackHandler>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IUseable obj))
            {
                EnabledUseButton(true);
                SetObj(obj);
            }
            if (other.gameObject.TryGetComponent(out IPickable objPick))
            {
                EnabledUseButton(true);
                SetObj(objPick);
            }
            if (other.gameObject.TryGetComponent(out IAttackable objAttack))
            {
                EnabledAttackButton(true);
                SetObj(objAttack);
            }
            if (other.gameObject.TryGetComponent(out IHitable objHit))
            {
                EnabledAttackButton(true);
                SetObj(objHit);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<IUseable>(out IUseable obj))
            {
                EnabledUseButton(false);
                UnSet(obj);
            }
            if (other.gameObject.TryGetComponent<IPickable>(out IPickable objPick))
            {
                EnabledUseButton(false);
                UnSet(objPick);
            }
            if (other.gameObject.TryGetComponent<IAttackable>(out IAttackable objAttack))
            {
                EnabledAttackButton(false);
                UnSet(objAttack);
            }
            if (other.gameObject.TryGetComponent<IHitable>(out IHitable objHit))
            {
                EnabledAttackButton(false);
                UnSet(objHit);
            }
        }

        private void SetObj(IUseable obj)
        {
            if (_useHandler.objectThatCanUse == null)
                _useHandler.objectThatCanUse = obj;
        }
        private void SetObj(IPickable obj)
        {
            if (_useHandler.objectThatCanPick == null)
                _useHandler.objectThatCanPick = obj;
        }
        private void SetObj(IAttackable obj)
        {
            if (_attackHandler.objectThatCanAttack == null)
                _attackHandler.objectThatCanAttack = obj;
        }
        private void SetObj(IHitable obj)
        {
            if (_attackHandler.objectThatHit == null)
                _attackHandler.objectThatHit = obj;
        }

        public void UnSet(IUseable obj)
        {
            if(_useHandler.objectThatCanUse == obj)
                _useHandler.objectThatCanUse = null;
        }
        public void UnSet(IPickable obj)
        {
            if (_useHandler.objectThatCanPick == obj)
                _useHandler.objectThatCanPick = null;
        }
        public void UnSet(IAttackable obj)
        {
            if (_attackHandler.objectThatCanAttack == obj)
                _attackHandler.objectThatCanAttack = null;
        }
        public void UnSet(IHitable obj)
        {
            if (_attackHandler.objectThatHit == obj)
                _attackHandler.objectThatHit = null;
        }

        public void EnabledUseButton(bool enable)
        {
            _useHandler.useButton.interactable = enable;
        }
        public void EnabledAttackButton(bool enable)
        {
            _attackHandler.attackButton.interactable = enable;
        }

        
    }
}