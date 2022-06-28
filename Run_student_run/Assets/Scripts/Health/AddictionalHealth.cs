using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddictionalHealth : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public AudioSource heart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            PlayHeart();
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }

    public void PlayHeart()
    {
        heart.Play();
    }

}
