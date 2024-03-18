using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameActor : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	// Need a reference to the canvas so that the canvas scale is accounted for when moving dragged objects
	[SerializeField] private Canvas canvas;

	private RectTransform rectTransform;

	// need a canvas group component in order to stop blocking raycasts while dragging the object
	// this is necessary in order for other actors to be able to detect having something dropped onto them,
	// since by default the OnDrop() event will be "captured" by the object being dropped, and not be detected by the object that's having something dropped onto it
	private CanvasGroup canvasGroup;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		//Debug.Log("OnBeginDrag");
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//Debug.Log("OnPointerDown");
	}

	// Called when something is dropped onto this object
	public virtual void OnDrop(PointerEventData eventData)
	{
		Debug.Log("parent on drop");
		if (eventData.pointerDrag != null)
		{
			// eventData.pointerDrag is the object that has been dropped onto this object
		}
	}
}
