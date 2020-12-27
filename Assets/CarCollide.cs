using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("ground")){
            car.GetComponent<CarController>().grounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.tag.Equals("ground")){
            car.GetComponent<CarController>().grounded = false;
        }
        // print("No longer in contact with " + other.collider.tag);
    }
}
