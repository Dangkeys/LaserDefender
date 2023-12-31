using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>(); 
    }
    public int GetHealth(){return health;}
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer == null) return;
        TakeDamage(damageDealer.GetDamage());
        audioPlayer.PlayDamageClip();
        PlayHitEffect();
        ShakeCamera();
        damageDealer.Hit();
    }

    private void ShakeCamera()
    {
        if(applyCameraShake && cameraShake != null)
            cameraShake.Play();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }
    void Die()
    {
        if(!isPlayer)
            scoreKeeper.ModifyScore(score);
        else
            levelManager.LoadGameOver();
        Destroy(gameObject);
    }


    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
