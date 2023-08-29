using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChanger : MonoBehaviour
{

    public GameObject FirstPersonCameraHolder;
    public GameObject ThirdPersonCameraHolder;
    public int CamMode;
    public bool isFirstEnabled;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CameraSwitch"))
        {
            if(isFirstEnabled)
            {

                isFirstEnabled = false;
            } else
            {

                isFirstEnabled = true;
            }

            StartCoroutine(DoChange());
        }
    }

    IEnumerator DoChange()
    {
        yield return new WaitForSeconds(0.01f);

        if(isFirstEnabled)
        {
            ThirdPersonCameraHolder.SetActive(true);
            FirstPersonCameraHolder.SetActive(false);
        } else
        {
            ThirdPersonCameraHolder.SetActive(false);
            FirstPersonCameraHolder.SetActive(true);
        }
    }
}
