using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CenterOnClickedObject : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private CinemachineFreeLook thirdPersonCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Set target
                target = hit.transform.gameObject;
            }
        }

        //set transform of this object
        transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
        // - Maybe move to separate script
        thirdPersonCamera.m_LookAt = target.transform;
    }
}
