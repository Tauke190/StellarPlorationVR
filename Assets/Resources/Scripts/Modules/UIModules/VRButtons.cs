using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class VRButtons : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler,IPointerUpHandler,IPointerClickHandler,IDragHandler
{

    public Color normalcolor = Color.white;
    public Color hovercoler = Color.red;
    public Color downcolor = Color.grey;


    public UnityEvent OnClick = null;
    public UnityEvent OnHover =null;
    public UnityEvent OnExit =null;
    public UnityEvent OnVRPointerDown =null;
    public UnityEvent OnDrag = null;
    public UnityEvent OnVRPointerUp;


    private Image image;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(OnClick!=null)
           OnClick.Invoke();

        image.color = downcolor;
    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(OnVRPointerDown!=null)
           OnVRPointerDown.Invoke();
       
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(OnHover !=null)
           OnHover.Invoke();
        image.color = hovercoler;
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(OnExit!=null)
           OnExit.Invoke();
        image.color = normalcolor;
   
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnVRPointerUp != null)
            OnVRPointerUp.Invoke();

        image.color = normalcolor;
   
    }

    void Start()
    {
        image = GetComponent<Image>();
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("Fuck you Bitch");
    }
}
