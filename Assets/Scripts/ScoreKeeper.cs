using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] [Range(0f, int.MaxValue)] int score;
    public int GetScore(){return score;}
    public void ModifyScore(int value){score += value;Debug.Log(score);}
    public void ResetScore(){score = 0;}
}
