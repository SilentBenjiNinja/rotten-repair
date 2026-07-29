using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCatcher : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        print("drop " + eventData.pointerDrag + " " + this.gameObject.name);

        // TO DO: handle zombie setup according to eventData.pointerDrag
    }
}
