using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour
{
    public GameObject car;
    public GameManager gameManager;
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
        if(collision.collider.tag.Equals("ground") || collision.collider.tag.Equals("goal")){
            car.GetComponent<CarController>().grounded = true;
        }
        if(collision.collider.tag.Equals("goal")){  // if touched goal
        for(int i = 0; i < gameManager.attachedAnimals.Count; i++){
                gameManager.count_animal(gameManager.attachedAnimals[i].tag);
            }

            for(int i = 0; i < gameManager.animals_on_scene.Count; i++){
                Destroy(gameManager.animals_on_scene[i]);
            }
            gameManager.spawnAnimals();
           
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.tag.Equals("ground") || other.collider.tag.Equals("goal")){
            car.GetComponent<CarController>().grounded = false;
        }
        // print("No longer in contact with " + other.collider.tag);
    }
}
