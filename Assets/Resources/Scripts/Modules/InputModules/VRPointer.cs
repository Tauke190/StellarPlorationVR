using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(LineRenderer))]
public class VRPointer : MonoBehaviour
{

    public VRInputModule inputmodule;
    public GameObject DotPrefab;
    public float DefaultLength = 5f;
    private LineRenderer lineRenderer;
    private bool onlefthand;
    private bool onrighthand;
    GameObject Dot;

   private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Dot = Instantiate(DotPrefab);
        Dot.transform.SetParent(gameObject.transform);
    }
    private void Update()
    {
        UpdateLine();
    }
    private void UpdateLine( )
    {
        PointerEventData data = inputmodule.GetData();
        
        //Set Default Length 
        float targetlength = data.pointerCurrentRaycast.distance == 0 ?DefaultLength:data.pointerCurrentRaycast.distance;
        //Return a hit information 
        RaycastHit hit = CreateRaycast(targetlength);
        //Find the endpositon
        Vector3 endposition = transform.position + (transform.forward * targetlength);
        //if hits something 

        if (hit.collider != null)
            endposition = hit.point;

        Dot.transform.position = endposition;
        //Draw Line
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endposition);
    }
    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, DefaultLength);
        return hit;
    }
}
