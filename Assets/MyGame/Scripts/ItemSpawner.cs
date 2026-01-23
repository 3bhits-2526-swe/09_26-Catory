using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Was soll gespawnt werden?")]
    public GameObject worldItemPrefab;

    [Header("UI Settings")]
    public Canvas mainCanvas;

    private GameObject dragIconObject;
    private RectTransform dragRectTransform;
    private CanvasGroup dragCanvasGroup;

    private void Awake()
    {

        if (mainCanvas == null) mainCanvas = GetComponentInParent<Canvas>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        dragIconObject = new GameObject("DragIcon");
        dragIconObject.transform.SetParent(mainCanvas.transform, false);
        

        Image myImage = GetComponent<Image>();
        Image dragImage = dragIconObject.AddComponent<Image>();
        dragImage.sprite = myImage.sprite;
        dragImage.raycastTarget = false;


        dragRectTransform = dragIconObject.GetComponent<RectTransform>();
        dragRectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        
        dragCanvasGroup = dragIconObject.AddComponent<CanvasGroup>();
        dragCanvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragRectTransform != null)
        {
            dragRectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool success = GridController.Instance.TrySpawnItemAt(worldItemPrefab, Input.mousePosition);

        if (success)
        {
            Debug.Log("Item erfolgreich platziert!");
        }
        else
        {
            Debug.Log("Platzierung fehlgeschlagen (voll oder ungültig).");
        }

        Destroy(dragIconObject);
    }
}