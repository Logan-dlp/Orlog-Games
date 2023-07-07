using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFunction : MonoBehaviour
{
    public bool Interactable = false;
    
    private string[] FaceDice;

    private void Start()
    {
        AddFaceDice();
    }

    /// <summary>
    /// defines the faces of the dice.
    /// </summary>
    void AddFaceDice()
    {
        FaceDice[0] = "axe";
        FaceDice[1] = "arrow";
        FaceDice[2] = "shield";
        FaceDice[3] = "axe";
        FaceDice[4] = "hand";
        FaceDice[5] = "helmet";
    }
}
