using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public int bookValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(bookValue);
            PlayBook();
        }
    }

    public AudioSource book;

    public void PlayBook()
    {
        book.Play();
    }
}
