using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int[,] tiles;

    public Player(int col, int row)
    {
        col = col;
        row = row;
        tiles = new int[row, col];

        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                tiles[i, j];
            }
        }
    }

    public void Range()
	{
        Vector3 playerPos = findObjectOfTyper<Player>().transform.position;
        int playerCol = playerPos.x;
        int playerRow = playerPos.y;

        for(int i = (playerCol - 5); i < playerCol + 5; i++)
        {
            for(int j = (playerRow - 5); i < (playerRow + 5); j++)
            {

            }
        }
	}
}
