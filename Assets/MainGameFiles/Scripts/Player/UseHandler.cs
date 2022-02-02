using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseHandler : MonoBehaviour
{
    [SerializeField] private Button _useButton;

    private IUseable _objectThatCanUse;

    public Button useButton => _useButton;
    public IUseable objectThatCanUse { get => _objectThatCanUse; set => _objectThatCanUse = value; }

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
        
    }
}
