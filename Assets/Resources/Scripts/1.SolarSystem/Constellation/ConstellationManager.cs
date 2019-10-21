using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstellationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] constellations;

    [SerializeField]
    public GameObject currentConstellation;

    [SerializeField]
    private float transistionSpeed = 10;

    int currentChildIndex = 0;

    bool limitAnimation;

    GameObject previousConstellation;

    bool goingLeft;

    [SerializeField]
    private Text nameText;

    void Start()
    {
        currentConstellation = Instantiate(constellations[0], new Vector3(0, 15, 0), Quaternion.identity) as GameObject;
        nameText.text = constellations[0].name;
    }

    private void Update()
    {
        if (limitAnimation)
        {
            Vector3 point = new Vector3();
            point = goingLeft ? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);
            currentConstellation.transform.position = Vector3.Lerp(currentConstellation.transform.position, point, Time.deltaTime * transistionSpeed * 2);
            if(Vector3.Distance(currentConstellation.transform.position, point) <= 0.1)
            {
                limitAnimation = false;
            }
        }
        else
        {
            if (Vector3.Distance(currentConstellation.transform.position, Vector3.zero) <= 0.1)
            {
                return;
            }
            currentConstellation.transform.position = Vector3.Lerp(currentConstellation.transform.position, Vector3.zero, Time.deltaTime * transistionSpeed);
        }

        if(previousConstellation != null)
        {
            Vector3 point = new Vector3();
            point = goingLeft ? new Vector3(-20, 0, 0) : new Vector3(20, 0, 0);
            previousConstellation.transform.position = Vector3.Lerp(previousConstellation.transform.position, point, Time.deltaTime * transistionSpeed);
            if (Vector3.Distance(previousConstellation.transform.position, point) <= 0.1)
            {
                Destroy(previousConstellation);
            }
        }
    }

    public void Next()
    {
        foreach (Draw_Type2 lr in FindObjectsOfType<Draw_Type2>())
        {
            Destroy(lr.gameObject);
        }

        goingLeft = true;

        if (currentChildIndex == constellations.Length - 1)
        {
            limitAnimation = true;
            return;
        }

        if(previousConstellation != null)
        {
            Destroy(previousConstellation);
        }

        previousConstellation = currentConstellation;

        currentChildIndex++;

        currentConstellation = Instantiate(constellations[currentChildIndex], new Vector3(20, 0, 0), Quaternion.identity) as GameObject;

        nameText.text = constellations[currentChildIndex].name;
    }

    public void Previous()
    {
        foreach (Draw_Type2 lr in FindObjectsOfType<Draw_Type2>())
        {
            Destroy(lr.gameObject);
        }

        goingLeft = false;

        if (currentChildIndex == 0)
        {
            limitAnimation = true;
            return;
        }

        if (previousConstellation != null)
        {
            Destroy(previousConstellation);
        }

        previousConstellation = currentConstellation;

        currentChildIndex--;

        currentConstellation = currentConstellation = Instantiate(constellations[currentChildIndex], new Vector3(-20, 0, 0), Quaternion.identity) as GameObject;

        nameText.text = constellations[currentChildIndex].name;
    }
}
