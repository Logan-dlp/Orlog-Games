using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceFunction : MonoBehaviour, Interact
{
    public DiceParameter DiceParameter;
    
    public bool FixResult = false;
    public bool Interactable = false;
    public string ResultDice;

    private string[] FaceDice;
    private Rigidbody rb;
    private bool haveCollision = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        AddFaceDice();
    }

    private void OnCollisionStay(Collision _collision)
    {
        if (_collision.gameObject.layer == LayerMask.NameToLayer("CollisionDiceTrue")) haveCollision = true;
        else haveCollision = false;
    }

    public void Interaction(GameObject _object)
    {
        Player _player = _object.GetComponent<Player>();
        switch (ResultDice)
        { 
            case "axe": _player.axe++; 
                break;
            case "arrow": _player.arrow++; 
                break;
            case "shield": _player.shield++; 
                break;
            case "hand": _player.hand++; 
                break;
            case "helmet": _player.helmet++; 
                break;
        }
        FixResult = true;
        Interactable = false;
    }

    public bool IsInteractable()
    {
        return Interactable;
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
    public void RollDice()
    {
        int _rand = Random.Range(0, FaceDice.Length);
        ResultDice = FaceDice[_rand];
        if (haveCollision)
        {
            if (rb.IsSleeping())
            {
                transform.eulerAngles = DiceParameter.DiceFaceRotation[_rand];
                Interactable = true;
            }
        }
    }
}
