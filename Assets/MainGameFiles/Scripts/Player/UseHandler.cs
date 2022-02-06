using MainGameFiles.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace MainGameFiles.Scripts.Player
{
    public class UseHandler : MonoBehaviour
    {
        [SerializeField] private Button _useButton;

        private IUseable _objectThatCanUse;
        private IPickable _objectThatCanPick;

        public Button useButton => _useButton;
        public IUseable objectThatCanUse { get => _objectThatCanUse; set => _objectThatCanUse = value; }
        public IPickable objectThatCanPick { get => _objectThatCanPick; set => _objectThatCanPick = value; }

        private void Start()
        {
            _useButton.interactable = false;
        }

        public void Click()
        {
            if (_objectThatCanUse != null)
            {
                _objectThatCanUse.Use();
            }
            if (_objectThatCanPick != null)
            {
                _objectThatCanPick.Pick();
            }

        }
    }
}
