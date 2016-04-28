using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utilities  {

	public static float AngleBetweenVectors(Vector3 fwd,Vector3 targetDir)
	{
		float Angle = Vector3.Angle (fwd, targetDir);
		if(AngleDir(fwd, targetDir) == 1)
		{
			return Angle;
		}
		return -Angle;
	}

	//returns -1 when to the left, 1 to the right, and 0 for forward/backward
	public static int AngleDir(Vector3 fwd,Vector3 targetDir) {
		Vector3 perp  = Vector3.Cross(fwd, targetDir);
		float dir  = Vector3.Dot(perp, Vector3.up);
		
		if (dir > 0.0f) {
			return 1;
		} else if (dir < 0.0f) {
			return -1;
		} else {
			return 0;
		}
	}

    public static string RemoveCloneFromName(string name)
    {
        if(name.Contains("Clone"))
        {
            name = name.Substring(0, name.Length - 7);
        }
        return name;
    }

    public static  Transform GetNearestTransformInList(Transform point, List<Transform> otherPoints)
    {
        float nearestDistance = float.MaxValue;
        Transform nearestTransform = null;

        foreach (Transform top in otherPoints)
        {
            if (top != point)
            {
                if ((top.position - point.position).sqrMagnitude < nearestDistance)
                {
                    nearestDistance = (top.position - point.position).sqrMagnitude;
                    nearestTransform = top;
                }
            }
        }
        return nearestTransform;
    }

    public static Transform GetNearestTransformInList(Transform point, List<GameObject> otherPoints)
    {
        float nearestDistance = float.MaxValue;
        Transform nearestTransform = null;

        foreach (GameObject top in otherPoints)
        {
            if (top != point)
            {
                if ((top.transform.position - point.position).sqrMagnitude < nearestDistance)
                {
                    nearestDistance = (top.transform.position - point.position).sqrMagnitude;
                    nearestTransform = top.transform;
                }
            }
        }
        return nearestTransform;
    }

    public static Transform GetNearestTransformInList(Transform point, Transform[] otherPoints)
    {
        float nearestDistance = float.MaxValue;
        Transform nearestTransform = null;

        foreach (Transform top in otherPoints)
        {
            if (top != point)
            {
                if ((top.position - point.position).sqrMagnitude < nearestDistance)
                {
                    nearestDistance = (top.position - point.position).sqrMagnitude;
                    nearestTransform = top;
                }
            }
        }
        return nearestTransform;

    }

    public static Transform GetNearestTransformInList(Transform point, GameObject[] otherPoints)
    {
        float nearestDistance = float.MaxValue;
        Transform nearestTransform = null;

        foreach (GameObject top in otherPoints)
        {
            if (top.transform != point)
            {
                if ((top.transform.position - point.position).sqrMagnitude < nearestDistance)
                {
                    nearestDistance = (top.transform.position - point.position).sqrMagnitude;
                    nearestTransform = top.transform;
                }
            }
        }
        return nearestTransform;

    }

    public static float GetDistance(Transform pointA, Transform pointB)
    {
       // Debug.Log(pointA.name );
        return (pointA.position - pointB.position).magnitude;
    }

    public static float GetDistance(Vector3 pointA, Vector3 pointB)
    {
        return (pointA - pointB).magnitude;
    }

    public static float GetDistanceSQRD(Transform pointA, Transform pointB)
    {
        // Debug.Log(pointA.name );
        return (pointA.position - pointB.position).sqrMagnitude;
    }

    public static float GetDistanceSQRD(Vector3 pointA, Vector3 pointB)
    {
        return (pointA - pointB).sqrMagnitude;
    }
}

public class PerlinRandom
{
	private static float offset = 0f;
	private static float seed = 0f;

	public static void SeedPerlinRandom(float Seed)
	{
		seed = Seed;
		offset = seed;
	}

    public static void ResetSeed()
    {
        offset = seed;
    }

	public static float Range(float min, float max)
	{
		//return Random.Range (min, max);
		offset += 3.22f ;

		//Debug.Log ("offset " + offset.ToString ());
		float f = Mathf.PerlinNoise (offset * 40.0400f, offset * 40.0100f) * 2f;
        if (f > 1f)
            f = f - (float)((int)f);

		return Mathf.Clamp( f * (max - min) + min, min, max);

	}



	public static int Range(int min, int max)
	{
		//return Random.Range (min, max);
		offset += 3.22f;

        float f = Mathf.PerlinNoise(offset * 40.0400f, offset * 40.0100f) * 2f;
        if (f > 1f)
            f = f - (float)((int)f);

		return Mathf.Clamp( (int)(f * (max - min)) + min, min, max-1);
		
	}

	/*private static float random01f()
	{
		float f = Mathf.PerlinNoise (offset * 0.0400f, offset * 0.01300f);
		f = f * 10f;
		f = f - (int)f;
		return f;
	}*/


}

public class Vec2i {
	public int x;
	public int y;

	public Vec2i(int X, int Y)
	{
		x = X;
		y = Y;
	}

	public Vec2i()
	{
		x = 0;
		y = 0;
	}

	public static bool operator ==(Vec2i a, Vec2i b)
	{
		// If both are null, or both are same instance, return true.
		if (System.Object.ReferenceEquals(a, b))
		{
			return true;
		}
		
		// If one is null, but not both, return false.
		if (((object)a == null) || ((object)b == null))
		{
			return false;
		}
		
		// Return true if the fields match:
		return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=(Vec2i a, Vec2i b)
	{
		return !(a == b);
	}

	public static Vec2i operator + (Vec2i a, Vec2i b)
	{
		return new Vec2i(a.x + b.x, a.y + b.y);
	}

	public static Vec2i operator - (Vec2i a, Vec2i b)
	{
		return new Vec2i(a.x - b.x, a.y - b.y);
	}
}
