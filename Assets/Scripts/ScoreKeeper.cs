using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    private void Awake() {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    [SerializeField] [Range(0f, int.MaxValue)] int score;
    public int GetScore(){return score;}
    public void ModifyScore(int value){score += value;Debug.Log(score);}
    public void ResetScore(){score = 0;}
}
