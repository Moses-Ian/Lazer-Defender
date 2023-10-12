using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;

    public bool isFiring;
    Coroutine firingCoroutine;
    [SerializeField] float firingDelay = 0.2f;

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
            GameObject instance = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.identity
            );

            Rigidbody2D rigidBody = instance.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            yield return new WaitForSeconds(firingDelay);
        }
    }
}
