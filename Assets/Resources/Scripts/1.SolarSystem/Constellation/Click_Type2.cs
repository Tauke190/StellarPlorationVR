using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click_Type2 : MonoBehaviour 
{
    private bool isDrawing;

    private void OnMouseDown()
    {
        isDrawing = true;
        LineDrawer_Type2.instance.InstantiateLinePrefab(transform.position);
    }

    private void OnMouseUp()
    {
        isDrawing = false;
        LineDrawer_Type2.instance.FinishLine();
    }

    private void OnMouseEnter()
    {
        LineDrawer_Type2.instance.UpdatePoint(transform.position);
    }
}
