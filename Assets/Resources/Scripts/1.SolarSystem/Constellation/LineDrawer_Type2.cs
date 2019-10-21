using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer_Type2 : MonoBehaviour
{
    public static LineDrawer_Type2 instance;

    [SerializeField]
    private GameObject linePrefab;

    GameObject currentLinePrefab;

    bool draw;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            instance = this;
        }
    }

    public void InstantiateLinePrefab(Vector3 _position)
    {
        draw = true;
        currentLinePrefab = Instantiate(linePrefab, _position, Quaternion.identity) as GameObject;
        currentLinePrefab.GetComponent<Draw_Type2>().isDrawing = true;
    }

    public void FinishLine()
    {
        draw = false;
        currentLinePrefab.GetComponent<Draw_Type2>().FinishDrawing();
    }

    public void UpdatePoint(Vector3 _position)
    {
        if (draw)
        {
            currentLinePrefab.GetComponent<Draw_Type2>().PositionUpdate(_position);
        }
    }

    public void Reset()
    {
        foreach (LineRenderer lr in FindObjectsOfType<LineRenderer>())
        {
            Destroy(lr.gameObject);
        }
    }
}
