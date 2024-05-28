using Dreamteck.Splines;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SplineController _splineController;
    [SerializeField] private SwipeController _swipeController;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private Cube _cube;
    [SerializeField] private float _cubeSpeed;

    public static GameManager Instance { get; private set; }
    public bool IsCubeFly { get; private set; }
    
    private Cube _currentCube;
    
    private void Start()
    {
        Instance = this;
        
        _swipeController.SwipeStarted += OnSwipeStarted;
        _swipeController.SwipeEnded += OnSwipeEnded;
    }

    private void OnSwipeStarted()
    {
        if (_currentCube == null)
        {
            _currentCube = Instantiate(_cube, _spawnpoint.position, Quaternion.identity);
            _currentCube.FlyEnded += OnCubeFlyEnded;
        }
    }

    private void OnCubeFlyEnded()
    {
        if (_currentCube != null)
        {
            _currentCube.GetComponent<SplineFollower>().enabled = false;
            _currentCube = null;
            IsCubeFly = false;
        }
    }

    private void OnSwipeEnded()
    {
        if (_currentCube != null)
        {
            _currentCube.Launch(_splineController.SplineComputer, _cubeSpeed);
            IsCubeFly = true;
        }
    }
}