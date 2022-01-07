using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    /*
     I dont even know, probably not bad but good luck
     */

    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private float m_Speed;


    void Update()
    {
        Vector3 lTargetDir = m_Target.position - transform.position;
        lTargetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * m_Speed);
    }
}
