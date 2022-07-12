using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verbale : MonoBehaviour
{
    [SerializeField] private PlayerMobileInput input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource verbale;

    public void PlayVerbale()
    {
        verbale.Play();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
        PlayVerbale();
        input.WinGame();
    }
    }
}
