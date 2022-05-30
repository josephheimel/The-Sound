using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FindCircleCircleIntersections : MonoBehaviour
{
        // Find the points where the two circles intersect.
    public int IntersectionFinder(Vector2 center0, float radius0, Vector2 center1, float radius1, out Vector2 intersection0, out Vector2 intersection1)
    {
        // Find the distance between the centers.
        double dx = center0.x - center1.x;
        double dy = center0.y - center1.y;
        double dist = Math.Sqrt(dx * dx + dy * dy);
 
        if (Math.Abs(dist - (radius0 + radius1)) < 0.00001)
        {
            intersection0 = Vector2.Lerp(center0, center1, radius0 / (radius0 + radius1));
            intersection1 = intersection0;
            return 1;
        }
     
        // See how many solutions there are.
        if (dist > radius0 + radius1)
        {
            // No solutions, the circles are too far apart.
            intersection0 = new Vector2(float.NaN, float.NaN);
            intersection1 = new Vector2(float.NaN, float.NaN);
            return 0;
        }
        else if (dist < Math.Abs(radius0 - radius1))
        {
            // No solutions, one circle contains the other.
            intersection0 = new Vector2(float.NaN, float.NaN);
            intersection1 = new Vector2(float.NaN, float.NaN);
            return 0;
        }
        else if ((dist == 0) && (radius0 == radius1))
        {
            // No solutions, the circles coincide.
            intersection0 = new Vector2(float.NaN, float.NaN);
            intersection1 = new Vector2(float.NaN, float.NaN);
            return 0;
        }
        else
        {
            // Find a and h.
            double a = (radius0 * radius0 -
                        radius1 * radius1 + dist * dist) / (2 * dist);
            double h = Math.Sqrt(radius0 * radius0 - a * a);
 
            // Find P2.
            double cx2 = center0.x + a * (center1.x - center0.x) / dist;
            double cy2 = center0.y + a * (center1.y - center0.y) / dist;
 
            // Get the points P3.
            intersection0 = new Vector2(
                (float)(cx2 + h * (center1.y - center0.y) / dist),
                (float)(cy2 - h * (center1.x - center0.x) / dist));
            intersection1 = new Vector2(
                (float)(cx2 - h * (center1.y - center0.y) / dist),
                (float)(cy2 + h * (center1.x - center0.x) / dist));
         
            return 2;
        }
    }
}