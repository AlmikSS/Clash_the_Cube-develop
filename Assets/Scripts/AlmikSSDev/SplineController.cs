using Dreamteck.Splines;
using UnityEngine;

public class SplineController : MonoBehaviour
{
    [SerializeField] private SwipeController _controller;
    [SerializeField] private SplineComputer _spline;
    [SerializeField] private float _power;

    public SplineComputer SplineComputer => _spline;
    
    private void Awake()
    {
        _controller.SwipeEnded += OnSwipeEnded;
        _controller.Swipe += OnSwipe;
    }

    private void OnSwipe(Vector3 delta)
    {
        SplinePoint firstPoint = _spline.GetPoint(2);
        firstPoint.position = new Vector3(delta.x * _power, 1, delta.y * _power);
        _spline.SetPoint(2, firstPoint);
        
        SplinePoint secondPoint = _spline.GetPoint(1);
        secondPoint.position = new Vector3(delta.x / 2 * _power, 3, delta.y / 2 * _power);
        _spline.SetPoint(1, secondPoint);
    }

    private void OnSwipeEnded()
    {
        
    }
}