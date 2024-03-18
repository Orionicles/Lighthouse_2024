using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameDropslot : MinigameActor
{
	public override void OnDrop(PointerEventData eventData)
	{
		Debug.Log("child on drop");
		base.OnDrop(eventData);

		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
		}
	}
}
