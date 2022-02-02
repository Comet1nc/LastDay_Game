using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    private UseHandler _useHandler;

    private void Start()
    {
        _useHandler = GetComponent<UseHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IUseable>(out IUseable obj))
        {
            TurnOnOrOffUseButton(true);
            SetObj(obj);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<IUseable>(out IUseable obj))
        {
            TurnOnOrOffUseButton(false);
            UnSet(obj);
        }
    }

    private void SetObj(IUseable obj)
    {
        if (_useHandler.objectThatCanUse == null)
            _useHandler.objectThatCanUse = obj;
    }

    private void UnSet(IUseable obj)
    {
        if(_useHandler.objectThatCanUse == obj)
            _useHandler.objectThatCanUse = null;
    }

    private void TurnOnOrOffUseButton(bool turnOn)
    {
        _useHandler.useButton.interactable = turnOn;
    }
}
