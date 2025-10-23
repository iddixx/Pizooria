
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DraggablePizza : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public GameObject dropZone;
    public GameObject pizzaObject;
    public Pizza pizza;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        originalPosition = rectTransform.anchoredPosition;
        transform.SetParent(originalParent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        bool isOverDropZone = false;
        Customer customer = null;

        if (dropZone != null)
        {
            RectTransform dropZoneRect = dropZone.GetComponent<RectTransform>();
            Vector2 localMousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(dropZoneRect, Input.mousePosition, null, out localMousePosition);
            
            if (dropZoneRect.rect.Contains(localMousePosition))
            {
                isOverDropZone = true;
                customer = dropZone.GetComponent<Customer>();
            }
        }

        if (isOverDropZone && customer != null)
        {
            customer.ReceivePizza(pizza);
            PizzaUIManager uiManager = FindObjectOfType<PizzaUIManager>();
            if (uiManager != null)
            {
                uiManager.RemovePizza(gameObject);
            }
        }
        else
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
