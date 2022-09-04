using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] bool useAI;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    [HideInInspector] public bool isFiring;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {

        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
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
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponentInParent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);


            if (useAI)
            {
                audioPlayer.PlayEnemyShootingClip();
                float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
                timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFireRate, float.MaxValue);
                yield return new WaitForSeconds(timeToNextProjectile);
            }
            else
            {
                audioPlayer.PlayShootingClip();
                yield return new WaitForSeconds(baseFiringRate);
            }
        }
    }
}
