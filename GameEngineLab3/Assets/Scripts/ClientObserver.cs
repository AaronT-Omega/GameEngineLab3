using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    public float damage = 10f;
    void Start()
    {
        // Finds the Player so that it can call it's functions 
        _playerStatus = (PlayerStatus) FindObjectOfType(typeof(PlayerStatus));
    }
    void OnGUI() // Sets up buttons to interact with
    {
        if (GUILayout.Button("Damage Player")) // Damages player by a set amount of damage
        {
            if (_playerStatus)
            {
                _playerStatus.TakeDamage(damage);
            }
        }
        
        if (GUILayout.Button("Turn On Fire")) // Toggles the On Fire status
        {
            if (_playerStatus)
            {
                _playerStatus.OnFire();
            }
        }
    }
}
