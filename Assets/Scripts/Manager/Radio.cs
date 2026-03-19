using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField] private AudioSource carRadio;
    [SerializeField] private List<AudioClip> radioSongs;

    void Start()
    {
        carRadio.PlayOneShot(radioSongs[0]);
    }

    void Update()
    {
        
    }
    
    
}
