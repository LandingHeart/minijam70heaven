using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFrontCollide : MonoBehaviour
{   
    public Rigidbody back;
    [SerializeField] public GameManager gameManager;

    public int curr_num_of_chicken = 0;
    public int curr_num_of_cow = 0;
    public int curr_num_of_sheep = 0;
    public int curr_num_of_pig = 0;
    public int curr_num_of_duck = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isAnimal(string tag){
        return tag.Equals("chicken") || tag.Equals("cow") || tag.Equals("duck") || tag.Equals("pig") || tag.Equals("sheep");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isAnimal(other.tag)){
            PlayAnimalSound(other.tag);
            other.transform.position = back.transform.position;
            other.gameObject.GetComponent<SpringJoint>().connectedBody = back;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<MeshCollider>().enabled = false;

            var animal_scale_x = other.transform.localScale.x;
            var animal_scale_y = other.transform.localScale.y;
            var animal_scale_z = other.transform.localScale.z;
            
            other.transform.localScale = new Vector3(animal_scale_x/3f, animal_scale_y/3f, animal_scale_z/3f);
        }
        
    }

    private void PlayAnimalSound(string tag){

    }
}
