using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int currentLives = 3;
    public int maxLives = 3;
    public int minimumLives = 0;

    [Header("DamageControl")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.5f;
    public float canTakeDamageCounter;
    
    public AudioClip[] hurtClips;
    public AudioClip[] pickupClips;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            if (currentLives >= maxLives) return;
                currentLives += 1; 
                _audioSource.PlayOneShot(pickupClips[Random.Range(0, pickupClips.Length)]);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Enemy"))
        {
            currentLives -= 1;
            _audioSource.PlayOneShot(hurtClips[Random.Range(0, hurtClips.Length)]);
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
            if (currentLives == minimumLives)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    } 
}
