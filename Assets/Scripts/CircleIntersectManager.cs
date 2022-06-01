using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleIntersectManager : MonoBehaviour
{
    //          Reformat so that the manager creates objects instead of referencing them

    // Serialized Fields
    [SerializeField] private GameObject trail0;
    [SerializeField] private GameObject trail1;
    [SerializeField] private GameObject circle0;
    [SerializeField] private GameObject circle1;
    [SerializeField] private float radius0;
    [SerializeField] private float radius1;

    // Privates
    private FindCircleCircleIntersections finder;
    private Vector2 intersect0;
    private Vector2 intersect1;

    void Start() {
        // Initialize radius to object default
        radius0 = circle0.transform.localScale.x;
        radius1 = circle1.transform.localScale.x;

        finder = new FindCircleCircleIntersections();
    }

    // Update is called once per frame
    void Update()
    {
        // Update Circle Radius
        circle0.transform.localScale = new Vector3(radius0, radius0, radius0);
        circle1.transform.localScale = new Vector3(radius1, radius1, radius1);
        
        // Update Intersection Points
        finder.IntersectionFinder(new Vector2(circle0.transform.position.x, circle0.transform.position.z), radius0, new Vector2(circle1.transform.position.x, circle1.transform.position.z), radius1, out intersect0, out intersect1);
        
        Debug.Log(intersect0);

        if(!float.IsNaN(intersect0.x))
        {
            
            trail0.transform.position = new Vector3(intersect0.x, 0, intersect0.y);
            trail1.transform.position = new Vector3(intersect1.x, 0, intersect1.y);
        }
    }
            //  Bug Fix Incorrect? circle intersections. Thanks babe
}
