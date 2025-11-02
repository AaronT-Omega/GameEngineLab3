using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    
    private float _currentHealth;
    private bool _isOnFire;
    private PlayerStatus _playerStatus;

    private void OnGUI() // Sets up GUI
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));

        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health: " + _currentHealth);
        GUILayout.EndHorizontal();


        if (_isOnFire) // When the On Fire state is toggled on, creates a warning for the player
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("BURNING");
            GUILayout.EndHorizontal();
        }

        if (_currentHealth <= 50.0f) // When HP is below or equal to 50, creates a warning for the player
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WARNING: Low Health");
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }

    public override void Notify(Subject subject) // Overides the Notify function
    {
        if (!_playerStatus)
        {
            _playerStatus = subject.GetComponent<PlayerStatus>();
        }

        if (_playerStatus)
        {
            
            _isOnFire = _playerStatus.IsOnFire;
            _currentHealth = _playerStatus.CurrentHealth;

        }
    }
}
