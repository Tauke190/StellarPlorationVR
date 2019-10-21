using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Draw_Type2 : MonoBehaviour
{
    [HideInInspector]
    public bool isDrawing;

    private LineRenderer _lineRenderer;

    private int currentPositionIndex = 1;

    private bool positionUpdating;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position);
    }

    void Update()
    {
        if (isDrawing)
        {
            DrawLine();
        }   
    }

    void DrawLine()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _lineRenderer.SetPosition(currentPositionIndex, pos);
    }

    public void FinishDrawing()
    {
        if (_lineRenderer.positionCount <= 2)
        {
            Destroy(gameObject);
        }
        else
        {
            isDrawing = false;
            _lineRenderer.positionCount--;
        }
    }

    public void PositionUpdate(Vector3 _position)
    {
        if (_lineRenderer == null)
            return;

        positionUpdating = true;
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(currentPositionIndex, _position);
        currentPositionIndex++;
        positionUpdating = false;
    }
}
