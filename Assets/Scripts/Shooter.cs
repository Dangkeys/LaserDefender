using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    
    [HideInInspector]public bool isFiring;
    Coroutine firingCoroutine;
    private void Start() {
        if(useAI)
        {
            isFiring = true;
        }
    }
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuously());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
            transform.position,
            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifeTime);
            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, 
            baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}