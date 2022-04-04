using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureRank : MonoBehaviour
{
    protected int rank;

    public void SetRank(int _rank)
    {
        this.rank = _rank;
    }

    public int GetRank()
    {
        return rank;
    }
}
