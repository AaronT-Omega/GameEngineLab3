using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : Observer
{
    private bool _isOnFire;
    //private float _currentHealth; || Didn't get time to implement damage


    private bool _timerStart = false;
    private bool _burnScreen = false;


    // Sets it up so when the varable changes, the _timerStart var changes once.
    // Honestly not sure how it fully works and can probably be clearer, but it works for now
    public bool BurnScreen 
    {
        get { return _burnScreen; } 
        set
        {
            if (_burnScreen != value)
            {
                _timerStart = !_timerStart;
            }
        }
    }

    [SerializeField] private Image _fireScreen;

    public float fadeDuration = 2f;
    
    
    private PlayerStatus _playerStatus;

    void FixedUpdate()
    {
        
        // When the On Fire, the fire filter will fade in. When it's off, the filter will fade out

        if (_isOnFire && _timerStart == false)
        {
           
            FadeIn();
            
        }
        else if (!_isOnFire && _timerStart == true)
        {
            FadeOut();
        }
       
    }



   
    // Calls another function to fade in or out, and changes the BurnScreen var so it only activates once
    public void FadeIn()
    {
        BurnScreen = !BurnScreen;
        StartCoroutine(DoFade(_fireScreen.color.a, 1f)); // Fade from transparent to opaque
    }

    public void FadeOut()
    {
        BurnScreen = !BurnScreen;
        StartCoroutine(DoFade(_fireScreen.color.a, 0f)); // Fade from opaque to transparent
    }


    private IEnumerator DoFade(float startAlpha, float endAlpha)
    {
        
        // Grabs the color values for the fire filter
        Color imageColor = _fireScreen.color;
        float alpha;

       float timer = 0f; // Sets up Timer
        
        while (timer < fadeDuration)
        {
            // Increases or Decreases the alpha until it meets the end Alpha while constantly updating the filter
            timer += Time.deltaTime;
            alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
            imageColor.a = alpha;
            _fireScreen.color = imageColor;
 
            yield return null; // Wait for the next frame
        }
        
        

        

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
            //_currentHealth = _playerStatus.CurrentHealth; || Didn't get time to implement damage

        }
    }
}
