using System;
using Dreamteck.Splines;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action FlyEnded;
    
    public void Launch(SplineComputer spline, float speed)
    {
        GetComponent<SplineFollower>().spline = spline;
        GetComponent<SplineFollower>().followDuration = 1;
        GetComponent<SplineFollower>().direction = Spline.Direction.Backward;
        GetComponent<SplineFollower>().followSpeed = speed;
        GetComponent<SplineFollower>().enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plate"))
            FlyEnded?.Invoke();
    }
}