using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwRandom : MonoBehaviour
{
    public AudioClip[] ow;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per framed
    void Update(){}
    
    public void Hurt()
    {
        source.clip = ow[Random.Range(0, ow.Length)];
        source.volume = Random.Range(1-volumeChangeMultiplier, 1);
        source.PlayOneShot(source.clip);
    }
}
