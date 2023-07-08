using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private GameManager manager;
    
    public bool IsMyTrun = false;
    
    public float PlayerLife = 15;
    public int DivineFavors = 0;
    public DiceFunction[] Dice;

    private int move = 3;
    
    public int axe = 0;
    public int arrow = 0;
    public int shield = 0;
    public int hand = 0;
    public int helmet = 0;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!IsMyTrun) return;
        
        bool _verifFixResult = false;
        for (int i = 0; i < Dice.Length; i++)
        {
            if (!Dice[i].FixResult)
            {
                _verifFixResult = false;
                break;
            }
            else
            {
                _verifFixResult = true;
            }
        }
        
        if (move <= 0 || _verifFixResult)
        {
            for (int i = 0; i < Dice.Length; i++)
            {
                Dice[i].FixResult = true;
            }
            manager.NextPlayer();
        }
    }

    void Rool()
    {
        move--;
        for (int i = 0; i < Dice.Length; i++)
        {
            if (!Dice[i].FixResult)
            {
                Dice[i].RollDice();
            }
        }
    }

    public void NextRound()
    {
        move = 3;
        axe = 0;
        arrow = 0;
        shield = 0;
        hand = 0;
        helmet = 0;
    }
}
