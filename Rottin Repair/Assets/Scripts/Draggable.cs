using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("begindrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("end drag");
        if (HasGameObjectWithName(eventData.hovered, "dropzone_table"))
        {
            // TO DO: stuff when dropping onto table
        }
        else if (HasGameObjectWithName(eventData.hovered, "dropzone_inventory"))
        {
            // TO DO: stuff when dropping into inventory
        }
    }

    private bool HasGameObjectWithName(List<GameObject> gameObjects, string name)
    {
        foreach (GameObject gObj in gameObjects)
        {
            if (gObj.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
