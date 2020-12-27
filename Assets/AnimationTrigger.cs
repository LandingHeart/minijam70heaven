using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particle;
    public bool stop;
    private float stopTimer;

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        stop = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(stop == true)
        {
            stopTimer += Time.deltaTime;
            

            if(stopTimer >= 0.7)
            {
                particle.Stop();
   
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            Debug.Log("collided player");
          
            particle.Play();
            stop = true;
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            stop = false;
            stopTimer = 0;
    }
}
