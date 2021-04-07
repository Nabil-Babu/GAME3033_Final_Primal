using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointRoute : MonoBehaviour
{
    public GameObject[] WayPoints;

    public GameObject GetFirstPoint()
    {
        if (WayPoints.Length <= 0) return null;
        return WayPoints[0];
    }

    public GameObject GetWayPointAtIndex(int index)
    {
        if (WayPoints.Length <= 0) return null;
        if (index > WayPoints.Length) return null;
        return WayPoints[index];
    }
}
