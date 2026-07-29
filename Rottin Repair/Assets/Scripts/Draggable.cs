using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image raycastImage;

    private void Awake()
    {
        raycastImage = this.gameObject.GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("begindrag " + this.gameObject.name);
        raycastImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (HasGameObjectWithName(eventData.hovered, "dropzone_table"))
        {
            print("table");
            // TO DO: stuff when dropping onto table
        }
        else if (HasGameObjectWithName(eventData.hovered, "dropzone_trash"))
        {
            print("trash");
            // TO DO: stuff when dropping into trash
        }
        else if (HasGameObjectWithName(eventData.hovered, "dropzone_inventory"))
        {
            print("inventory");
            // TO DO: stuff when dropping into inventory
        }
        raycastImage.raycastTarget = true;
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
