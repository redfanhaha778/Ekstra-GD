using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFollow : MonoBehaviour
{
    public Transform companion;
    public float followSpeed;
    public float followDistance;
    public int maxHealth;
    private int currentHealth;

    private int CompcurrentHealth;

    public int CompmaxHealth;

    private bool isInvincible = false;

    public float invincibilityDuration = 1.5f;

    public GameObject hpBarGreen;

    public GameObject hpBarRed;

    public Vector3 hpBarOffset = new Vector3(0f, 1f, 0f);

    public GameObject coinPrefab;
    void Start()
    {
        if (companion == null)
        {
            companion = GameObject.FindGameObjectWithTag("Companion").transform;
            if (companion == null)
            {
                Debug.LogError("Companion not found! Make sure Your companion has the correct tag.");
            }

            currentHealth = maxHealth;

            if (hpBarGreen != null && hpBarRed != null)
            {
                hpBarGreen.SetActive(false);
                hpBarRed.SetActive(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInvincible)
        {
            TakeDamage();
            Debug.Log("Companion Hit!");
        }
    }

    void TakeDamage()
    {
        currentHealth--;


        if (hpBarGreen != null && hpBarRed != null)
        {
            hpBarGreen.SetActive(true);
            hpBarRed.SetActive(true);
            UpdateHpBar();

            if (currentHealth <= 0)
            {
                Destroyed();
            }
        }
    }

    private void UpdateHpBar()
    {
        // float healthPercentage = (float)currentHealth / maxHealth;
        // Vector3 scale = hpBarGreen.transform.localScale;
        // scale.x = healthPercentage;
        // hpBarGreen.transform.localScale = scale;

        UIManager.Instance.UpdateCompanionHP(CompcurrentHealth, CompmaxHealth);
    }

    IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, companion.position, followSpeed * Time.deltaTime);
        if (hpBarGreen != null && hpBarRed != null)
        {
            hpBarGreen.transform.position = transform.position + hpBarOffset;
            hpBarRed.transform.position = transform.position + hpBarOffset;
        }


    //  float distance = Vector3.Distance(transform.position, companion.position);
    //  if (distance > followDistance)
    //  {
    //     Vector3 targetPosition = companion.position;
    //     targetPosition.z = transform.position.z;
    //     transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    //  }   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
            Debug.Log("Hit");
        }
    }

    void Destroyed()
    {
        UIManager.Instance.KillCount();

        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
