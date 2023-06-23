using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public Joystick joystick;
    public ParticleSystem dirtSplatter;
    public ParticleSystem explosion;
    public AudioClip crashSound;
    private float speed = 50.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    private AudioSource carAudio;
    
    private void Start()
    {
        carAudio = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        CarMove();
        CarEffects();

    }


    public void CarMove()
    {

        forwardInput = joystick.Vertical;
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        horizontalInput = joystick.Horizontal;
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }

    public void CarEffects()
    {
        if (forwardInput > 0)
        {
            if (!carAudio.isPlaying) carAudio.Play();
            if (!dirtSplatter.isPlaying) dirtSplatter.Play();
        }

        if (forwardInput < 0)
        {
            if (!carAudio.isPlaying) carAudio.Play();
            if (!dirtSplatter.isPlaying) dirtSplatter.Play();
        }

        else if (forwardInput == 0)
        {
            dirtSplatter.Stop();
            carAudio.Stop();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Obstacle"))

        {

            explosion.Play();
            carAudio.PlayOneShot(crashSound);

        }

    }

   
}
