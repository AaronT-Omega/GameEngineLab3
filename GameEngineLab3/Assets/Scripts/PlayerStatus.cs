using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Subject
{
 

    public bool IsOnFire
    {
        get; private set;
    }
   

    public float CurrentHealth
    {
        get { return health; }
    }

    private bool _isEngineOn;
    private bool _isOnFire;
    private HUDController _hudController;
    private CameraController _cameraController;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private GameObject _fireEffects;


    private void Awake() // Initializes HUDController, and assigns CameraController to its first intance
    {
        _hudController = gameObject.AddComponent<HUDController>();

        _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
    }

    private void Start()
    {
        StartGame();
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
    private void StartGame() // Notifies all observers about the start of the game
    {
        
        NotifyObservers();
    }
   

    public void OnFire() // Toggles the On Fire state and activates Fire Effects
    {

        IsOnFire = !IsOnFire;
        _fireEffects.SetActive(!_fireEffects.activeSelf);
        NotifyObservers();
    }
    public void TakeDamage(float amount) // Decreases health by amount,  notifies observers, and destroys game object if health is 0
    {
        health -= amount;
        NotifyObservers();
        if (health < 0)
            Destroy(gameObject);
    }

}
