using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    // UI
    public GameObject HiddenText;
    
    
    public bool IsRunning;
    public bool IsBowEquipped;
    public bool IsCrouched;
    private bool _isStealthed;
    public bool IsStealthed
    {
        get
        {
            return _isStealthed;
        }
        set
        {
            if (value)
            {
                HiddenText.SetActive(true);
            }
            else
            {
                HiddenText.SetActive(false);
            }

            _isStealthed = value;
        }
    }
    public bool IsAiming;

    public int CurrentArrows = 20; 
    public int TotalArrowLimit = 20; 
}
