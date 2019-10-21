﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class Vr_Pointer : MonoBehaviour {
   
    

	[SerializeField]
	private float laserlimit = 50f;
	[SerializeField]
	[Tooltip("The model of Left controller")]
	private Transform Left_controller;
	[SerializeField]
	[Tooltip("The model of Right controller")]
	private Transform right_controller;
	private bool isonlefthand;
	private bool isonrighthand;
	private LineRenderer laser;
	public LayerMask mask;


    public SteamVR_Action_Boolean TriggerClick;
    




    private Ray ray;



    public enum PLANETS

    {

        Nothing,Sun,Mercury,Venus,Earth,Mars,Jupiter,Saturn,Uranus,Neptune,Asteroid,
    }
    public PLANETS Handprojectionstate;
	void Awake()
	{
		laser = this.GetComponent<LineRenderer> ();
       
    }
	// Use this for initialization
	void Start () 
	{
       
		laser.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (TriggerClick.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isonrighthand = true;
            isonlefthand = false;

        }
        
		if(TriggerClick.GetStateDown(SteamVR_Input_Sources.LeftHand))
		{
			isonlefthand = true;
            isonrighthand = false;
		}
		if (isonrighthand) 
		{
			laser.enabled = true;
			PointerActivate (right_controller);

		}

		if (isonlefthand) 
		{
			laser.enabled = true;
			PointerActivate (Left_controller);
		}
        switch (Handprojectionstate)
        {

            case PLANETS.Nothing:
                UImanager.instance.EnableHandProjector(9, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
                break;

            case PLANETS.Sun:
              
                UImanager.instance.EnableHandProjector(0, true);

                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
            
                break;
            case PLANETS.Mercury:
               
                UImanager.instance.EnableHandProjector(1, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
              
                break;
            case PLANETS.Venus:
              
                UImanager.instance.EnableHandProjector(2, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
               
                break;
            case PLANETS.Earth:
              
                UImanager.instance.EnableHandProjector(3, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
            
                break;
            case PLANETS.Mars:
              
                UImanager.instance.EnableHandProjector(4, true);
            
                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
               
                break;
            case PLANETS.Jupiter:
               
                UImanager.instance.EnableHandProjector(5, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
               
                break;
            case PLANETS.Saturn:
              
                UImanager.instance.EnableHandProjector(6, true);

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(7, false);
                UImanager.instance.EnableHandProjector(8, false);
              

                break;
            case PLANETS.Uranus:
               
                UImanager.instance.EnableHandProjector(7, true);
         

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(8, false);
             

                break;
            case PLANETS.Neptune:

                UImanager.instance.EnableHandProjector(8, true);
          

                UImanager.instance.EnableHandProjector(0, false);
                UImanager.instance.EnableHandProjector(1, false);
                UImanager.instance.EnableHandProjector(2, false);
                UImanager.instance.EnableHandProjector(3, false);
                UImanager.instance.EnableHandProjector(4, false);
                UImanager.instance.EnableHandProjector(5, false);
                UImanager.instance.EnableHandProjector(6, false);
                UImanager.instance.EnableHandProjector(7, false);
             

                break;
            
        }
       






    }
	void PointerActivate(Transform rayorigin)
	{
		RaycastHit hit;
		if (Physics.Raycast (rayorigin.position, rayorigin.forward, out hit, laserlimit, mask))
		{
			ray.origin = rayorigin.position;
			ray.direction =  rayorigin.forward;
			laser.SetPosition (0, rayorigin.position);
			laser.SetPosition (1,  rayorigin.position+ray.direction * hit.distance);
            GameObject hitobject = hit.transform.gameObject;
            string planetstags = hitobject.tag;
            Debug.Log(planetstags);
           switch(planetstags)
            {
                
                case "Body":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {

                        CancelInvoke();
                        Handprojectionstate = PLANETS.Sun;
                        Invoke("Nothing", UImanager.instance.Time);

                    }
                    break;


                case "Mercury":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Mercury;
                        Invoke("Nothing", UImanager.instance.Time);
                    }

                    break;

                case "Venus":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {

                        CancelInvoke();
                        Handprojectionstate = PLANETS.Venus;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;

                case "Earth":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Earth;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;

                case "Mars":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Mars;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;
                case "Jupiter":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Jupiter;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;

                case "Saturn":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Saturn;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;

                case "Uranus":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Uranus;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;

                case "Neptune":
                    if (TriggerClick.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        CancelInvoke();
                        Handprojectionstate = PLANETS.Neptune;
                        Invoke("Nothing", UImanager.instance.Time);
                    }
                    break;
               
               
            }

		}
		else 
		{
			ray.origin = rayorigin.position;
			ray.direction = rayorigin.forward;
			laser.SetPosition (0,rayorigin.position);
            laser.SetPosition(1, rayorigin.position + ray.direction * laserlimit);
            
		}


        
	}

    void Nothing()
    {
        Handprojectionstate = PLANETS.Nothing;
    }
   


}

