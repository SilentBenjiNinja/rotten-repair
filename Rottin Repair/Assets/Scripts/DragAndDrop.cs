using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public bool isMouseDown;

    public Image[] arr_img_inventory;

    //public Image fromButton;
    //public Image toButton;
    public Image currentHoverImage;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDown();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            OnMouseUp();
        }


    }

    private void OnMouseDown()
    {
        if (isMouseDown) return;
        StartCoroutine(Drag(currentHoverImage));
    }

    private void OnMouseUp()
    {
        if (!isMouseDown) return;
        StartCoroutine(Drop(currentHoverImage));
    }

    private IEnumerator Drag(Image currentHoverImage)
    {
        yield return new WaitUntil(() => !isMouseDown);

    }

    private IEnumerator Drop(Image currentHoverImage)
    {
        yield return new WaitUntil(() => isMouseDown);
    }


}
