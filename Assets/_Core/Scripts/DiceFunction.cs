using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceFunction : MonoBehaviour, Interact
{
    public bool Interactable = false;
    
    private string[] FaceDice;

    private void Start()
    {
        AddFaceDice();
    }

    public void Interaction(GameObject _object)
    {
        if (Interactable)
        {
            Debug.Log("Cet objet est interactable !");
        }
        return;
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

    /// <summary>
    /// Mix of dice.
    /// </summary>
    public string RollDice()
    {
        string _debug = FaceDice[Random.Range(0, FaceDice.Length)];
        Debug.Log("Résultat du dès : " + _debug);
        return _debug;
    }
}
