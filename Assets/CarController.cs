﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const float SPEED_MULTIPLIER = 10f;
    public Rigidbody rb;
    public Transform visual;
    [SerializeField] private float forwardAccel;
    [SerializeField] private float reverseAccel;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float turnStrength;
    private float gravityForce = 10f;
    private float liftForce = 25f;
    public bool grounded;

    public AudioSource audio;
    public AudioClip flyMusic;
    public AudioClip normalMusic;
    public GameObject audioManager;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public GameObject back;

    private float dragOnGround = 3f;

    private float speedInput, turnInput;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
         
        }
        if(Input.GetAxis(VERTICAL) > 0){
            speedInput = Input.GetAxis(VERTICAL) * forwardAccel * SPEED_MULTIPLIER;
        }else if(Input.GetAxis(VERTICAL) < 0){
            speedInput = Input.GetAxis(VERTICAL) * reverseAccel * SPEED_MULTIPLIER;
        }

        turnInput = Input.GetAxis(HORIZONTAL);
        // if(grounded){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        // }

        visual.position = rb.transform.position;
    }

    private void FixedUpdate(){
        

        if(grounded){
            rb.drag = dragOnGround;
            audioManager = GameObject.Find("AudioManager");
            if(!audioManager.GetComponent<AudioSource>().isPlaying){
                audioManager.GetComponent<AudioSource>().clip = normalMusic;
                audioManager.GetComponent<AudioSource>().Play();
            }
            if(audioManager.GetComponent<AudioSource>().isPlaying && audioManager.GetComponent<AudioSource>().clip != normalMusic){
                audioManager.GetComponent<AudioSource>().clip = normalMusic;
                audioManager.GetComponent<AudioSource>().Play();
            }
        }else{
            rb.drag = 0.1f;
            speedInput /= 20f;
            rb.AddForce(Vector3.up * -gravityForce);
        }

        if(Mathf.Abs(speedInput) > 0){
            rb.AddForce(transform.forward * speedInput);
        }

        if (Input.GetKey(KeyCode.Space)){
            rb.AddForce(Vector3.up * liftForce);
            audioManager = GameObject.Find("AudioManager");
            if(gameManager.attachedAnimals.Count > 0){
                if(audioManager.GetComponent<AudioSource>().isPlaying && audioManager.GetComponent<AudioSource>().clip != flyMusic){
                    audioManager.GetComponent<AudioSource>().clip = flyMusic;
                    audioManager.GetComponent<AudioSource>().Play();
                }
            }
            
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            rb.AddForce(Vector3.up * -liftForce);
        }
        
        
    }

}
