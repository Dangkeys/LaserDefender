using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Slider healthSlider;
    [SerializeField] Health health;
    TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    private void Awake() {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        healthSlider = GetComponentInChildren<Slider>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start() {
        healthSlider.maxValue = 50;
    }
    private void Update() {
        DisPlayHealth();
        DisPlayScore();
    }
    void DisPlayHealth()
    {
        healthSlider.value = health.GetHealth();
    }
    void DisPlayScore()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("0000000");
    }
}
