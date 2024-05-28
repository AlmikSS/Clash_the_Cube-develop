using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public event Action SwipeEnded;
    public event Action<Vector3> Swipe;
    public event Action SwipeStarted;

    private Vector3 _mouseDelta;
    private Vector3 _startMousePosition;
    private bool _isInSwipeView;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isInSwipeView)
        {
            _startMousePosition = Input.mousePosition;
            SwipeStarted?.Invoke();
        }

        if (Input.GetMouseButton(0) && !GameManager.Instance.IsCubeFly)
        {
            _mouseDelta = (Input.mousePosition - _startMousePosition).normalized;
            Swipe?.Invoke(_mouseDelta);
        }

        if (Input.GetMouseButtonUp(0))
            SwipeEnded?.Invoke();
    }

    public void OnSwipeViewDown() => _isInSwipeView = true;

    public void OnSwipeViewUp() => _isInSwipeView = false;
}