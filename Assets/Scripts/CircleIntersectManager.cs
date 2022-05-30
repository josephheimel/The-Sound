using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleIntersectManager : MonoBehaviour
{
    //          Reformat so that the manager creates objects instead of referencing them

    // Objects
    [SerializeField] private GameObject circleA;
    [SerializeField] private GameObject circleB;
    [SerializeField] private float scaleA;
    [SerializeField] private float scaleB;

    void Start() {
        scaleA = circleA.transform.localScale.x;
        scaleB = circleB.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Circle Radius
        circleA.transform.localScale = new Vector3(scaleA, scaleA, scaleA);
        circleB.transform.localScale = new Vector3(scaleB, scaleB, scaleB);
        
        // Update Intersection Points

        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier
    }
}
