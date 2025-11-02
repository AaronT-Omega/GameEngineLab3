using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : Subject
{
    public bool IsTurboOn
    {
        get; private set;
    }

    public float CurrentHealth
    {
        get { return health; }
    }

    private bool _isEngineOn;
    private HUDController _hudController;
    private CameraController _cameraController;
    [SerializeField] private float health = 100.0f;


    private void Awake() // Initializes HUDController, and assigns CameraController to its first intance
    {
        _hudController = gameObject.AddComponent<HUDController>();

        _cameraController = (CameraController) FindObjectOfType(typeof(CameraController));
    }

    private void Start()
    {
        StartEngine();
    }

    void OnEnable() // Attaches observers when enabled
    {
        if (_hudController)
            Attach(_hudController);
        if (_cameraController)
            Attach(_cameraController);
    }
    void OnDisable() // Detaches observers when disabled
    {
        if (_hudController)
            Detach(_hudController);
        if (_cameraController)
            Detach(_cameraController);
    }
    private void StartEngine() // Notifies all observers about the state change
    {
        _isEngineOn = true;
        NotifyObservers();
    }
    public void ToggleTurbo() // Toggles on the Turbo State if engine is on and notifies all observers
    {
        if (_isEngineOn)
            IsTurboOn = !IsTurboOn;
        NotifyObservers();
    }
    public void TakeDamage(float amount) // Decreases health by amount, turns off Turbo, notifies observers, and destroys game object if health is 0
    {
        health -= amount;
        IsTurboOn = false;
        NotifyObservers();
        if (health < 0)
            Destroy(gameObject);
    }

}
