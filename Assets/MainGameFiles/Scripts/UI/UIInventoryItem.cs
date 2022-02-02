using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private Text _textAmount;
    [SerializeField] private RectTransform _rectTransformInventory;
    [SerializeField] private bool _IChestItem;

    public IInventoryItem item { get; private set; }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        if (_IChestItem)
        {
            _rectTransformInventory.SetAsFirstSibling();
        }
        else
        {
            _rectTransformInventory.SetAsLastSibling();
        }

        _canvasGroup.blocksRaycasts = false;
    }

    public void Refresh(IInventorySlot slot)
    {
        if(slot.isEmpty)
        {
            Cleanup();
        }

        item = slot?.item;
        _imageIcon.sprite = item?.info.spriteIcon;

        var textAmountEnabled = slot.amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);
        _imageIcon.gameObject.SetActive(true);

        if(textAmountEnabled)
        {
            _textAmount.text = $"x{slot.amount.ToString()}";
        }
    }

    private void Cleanup()
    {
        _textAmount.gameObject.SetActive(false);
        _imageIcon.gameObject.SetActive(false);
    }
}
