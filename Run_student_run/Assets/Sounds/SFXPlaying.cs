using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource book;
    public AudioSource jump;
    public AudioSource heart;
    public AudioSource verbale;
    public AudioSource scale7;

    public void PlayBook()
    {
        book.Play();
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayHeart()
    {
        heart.Play();
    }

    public void PlayVerbale()
    {
        verbale.Play();
    }

    public void PlayScale7()
    {
        scale7.Play();
    }
}
