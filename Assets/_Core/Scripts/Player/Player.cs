using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public float PlayerLife = 15;
    public int DivineFavors = 0;
    public GameObject[] Dice;

    private int axe = 0;
    private int arrow = 0;
    private int shield = 0;
    private int hand = 0;
    private int helmet = 0;
    
    private int playerPlaceInGame;
}
