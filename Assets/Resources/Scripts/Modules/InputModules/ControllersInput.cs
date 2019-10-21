//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;
//using UnityEngine.Events;

//public class ControllersInput : MonoBehaviour
//{

//    public static ControllersInput instance;
//    //Unity Events 
//    public static UnityEvent OnTouchDown = new UnityEvent();
//    public static UnityEvent OnTouchUp = new UnityEvent();


//    public static UnityEvent OnTouchpadLeftUp = new UnityEvent();
//    public static UnityEvent OnTouchpadRightup = new UnityEvent();


//    public SteamVR_Action_Boolean grab = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Grab");
//    public SteamVR_Action_Boolean Triggerclick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerClick");
//    public SteamVR_Action_Boolean touchpadclick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Touchpadclick");
//    public SteamVR_Action_Boolean touchpadtouch = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Touchpadtouch");
//    public SteamVR_Action_Vector2 touchpadpos = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Touchpadpos");
   

//    void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            Destroy(this);
//        }
      
//    }


//    void Update()
//    {
//        if (grab.GetLastStateDown(SteamVR_Input_Sources.Any))
//        {
//            interaction.Pickup();

//        }
//        if (grab.GetLastStateUp(SteamVR_Input_Sources.Any))
//        {
//            interaction.Drop();
//        }

//        GetControllersInput();
//    }


//    private void GetControllersInput()
//    {
//        if (touchpadtouch.GetStateDown(SteamVR_Input_Sources.Any))
//        {
//            if (OnTouchDown != null)
//            {
//                OnTouchDown.Invoke();

//            }

//        }
//        if (touchpadtouch.GetStateUp(SteamVR_Input_Sources.Any))
//        {
//            if (OnTouchUp != null)
//            {
//                OnTouchUp.Invoke();

//            }
//        }
//        Vector3 Touchoadpos = touchpadpos.GetAxis(SteamVR_Input_Sources.Any);

//        if (touchpadtouch.GetLastStateDown(SteamVR_Input_Sources.Any) && Touchoadpos.x < 0.5f)
//        {
//            if (OnTouchpadLeftUp != null)
//            {
//                OnTouchpadLeftUp.Invoke();

//            }
//        }

//        if (touchpadtouch.GetLastStateDown(SteamVR_Input_Sources.Any) && Touchoadpos.x >= 0.5f)
//        {
//            if (OnTouchpadRightup != null)
//            {
//                OnTouchpadRightup.Invoke();

//            }
//        }


//    }

//}
