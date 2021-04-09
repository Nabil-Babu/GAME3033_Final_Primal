using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool IsRunning;
    public bool IsBowEquipped;
    public bool IsCrouched;
    public bool IsStealthed;
    public bool IsAiming;

    public int CurrentArrows = 20; 
    public int TotalArrowLimit = 20; 
}
