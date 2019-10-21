using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Player : MonoBehaviour
{

    public delegate void PlayerDelegate();
    public static event PlayerDelegate Playerevent;
    public static Player instance;
    public Transform CameraVR;

    public SteamVR_Action_Boolean trackpadforward;
    public SteamVR_Action_Boolean trackpadbackward;
    public SteamVR_Action_Boolean trackpadcenter;
    public SteamVR_Action_Vector2 trackpadpos;
    
  



    [SerializeField] private float speed = 1;
    [SerializeField] private float rotationalspeed = 1;
    
   
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Playerevent += PlayerTranslation;//subscribed to the playertranslationevent
        Playerevent += PlayerRotation;
      
    }


    private void FixedUpdate()
    {
        Playerevent();
    }




    private void PlayerTranslation()
    {

        Quaternion cameraAngle = Quaternion.Euler(new Vector3(CameraVR.eulerAngles.x, CameraVR.eulerAngles.y, 0f));
        Vector3 cameraDirection = cameraAngle * Vector3.forward;
        //references the  camera child gameobjects parented to the player



        if (trackpadforward.GetState(SteamVR_Input_Sources.RightHand))
        {
            transform.Translate(cameraDirection * speed * Time.deltaTime);
            
        }
        if (trackpadbackward.GetState(SteamVR_Input_Sources.RightHand))
        {
            transform.Translate(-cameraDirection * speed * Time.deltaTime);
           
        }


    }

    private void PlayerRotation()
    {

        Vector2 rotationvalue = trackpadpos.GetAxis(SteamVR_Input_Sources.LeftHand);
        transform.Rotate(0.0f, rotationvalue.x, 0.0f);//rotational functionality just for exploration
        if (trackpadcenter.GetLastStateDown(SteamVR_Input_Sources.Any))
                                                      {
            transform.rotation = Quaternion.identity;//Orients the player to the right postion and direction
        }




    }

}
