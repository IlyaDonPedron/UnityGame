using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public ParticleSystem explosion;
    private Renderer coinRenderer;
    private AudioSource coinAudio;
    

    private void Start()
    {
        coinRenderer = GetComponent<Renderer>();
        coinAudio = GetComponent<AudioSource>();    
        
    }

    private void Update()
    {
      
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (rotationSpeed >= 1000)
        {
            rotationSpeed = 50;
        }

    }

    private void OnMouseDown()
    {
        
        ChangeColor();
        explosion.Play();
        rotationSpeed += 15;
        if (!coinAudio.isPlaying)
        {
            coinAudio.Play();
        }

    }

    private void ChangeColor()
    {
        
        
        Color newColor = new Color(Random.value, Random.value, Random.value);
        coinRenderer.material.color = newColor;
        
    }
}
