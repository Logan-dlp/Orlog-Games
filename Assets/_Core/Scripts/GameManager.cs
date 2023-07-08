using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Player> Player;
    private int PlayerInGame;
    private int countTurn = 0;

    void CoinStartGame()
    {
        PlayerInGame = Random.Range(0, Player.Count);
        Player[PlayerInGame].IsMyTrun = true;
    }

    public void NextPlayer()
    {
        Player[PlayerInGame].IsMyTrun = false;
        if (PlayerInGame >= Player.Count)
        {
            PlayerInGame = 0;
        }
        else
        {
            PlayerInGame++;
        }
        Player[PlayerInGame].IsMyTrun = true;
        countTurn++;
        if (countTurn == 2)
        {
            // Add Attack
            countTurn = 0;
        }
    }
}
