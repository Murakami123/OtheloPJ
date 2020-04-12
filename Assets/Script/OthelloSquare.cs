using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloSquare : MonoBehaviour
{
    public SquareState state;
    public void SetSquareType(SquareState state)
    {
        this.state = state;

        switch (state)
        {
            case SquareState.Okeru: break;
            case SquareState.Okenai: break;
            case SquareState.Black: break;
            case SquareState.White: break;
            default: break;
        }
    }


    public void OnTap(bool isBlack)
    {

    }

    private void SetColor(bool isBlack)
    {

    }
}

public enum SquareState
{
    Okeru = 1,
    Okenai,
    Black,
    White,
}
