using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject cow;
    [SerializeField] GameObject duck;
    [SerializeField] GameObject pig;
    [SerializeField] GameObject sheep;

    [SerializeField] Transform[] spwanPoints_group;
    List<Transform> spwanPoints = new List<Transform>();

    public List<GameObject> attachedAnimals = new List<GameObject>();
    public List<GameObject> animals_on_scene = new List<GameObject>();

    public int num_of_animals = 0;
    public int num_of_chicken = 0;
    public int num_of_cow = 0;
    public int num_of_sheep = 0;
    public int num_of_pig = 0;
    public int num_of_duck = 0;
    public float timer = 30f;


    // Start is called before the first frame update
    void Start()
    {
        spawnAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
        }else{
            Debug.Log("Game over " + num_of_animals + " " + num_of_chicken);
        }
        
    }

    public void spawnAnimals(){
        animals_on_scene = new List<GameObject>();
        attachedAnimals = new List<GameObject>();
        GameObject[] animals = {chicken, cow, duck, pig, sheep};
        for(int i = 0; i < spwanPoints_group.Length; i++){
            for(int j = 0; j < spwanPoints_group[i].childCount; j++){
                spwanPoints.Add(spwanPoints_group[i].GetChild(j));
            }
            
        }
        for(int i = 0; i < spwanPoints.Count; i++){
            int spawn = Random.Range(0, 2);
            if(spawn == 1){
                var animal = Instantiate(animals[Random.Range(0, animals.Length)], spwanPoints[i].position, Quaternion.identity);
                var animal_scale_x = animal.transform.localScale.x;
                var animal_scale_y = animal.transform.localScale.y;
                var animal_scale_z = animal.transform.localScale.z;

                animal.transform.localScale = new Vector3(animal_scale_x*1.5f, animal_scale_y*1.5f, animal_scale_z*1.5f);
                animals_on_scene.Add(animal.gameObject);
            }
        }
    }

    public void count_animal(string tag){
        if(tag.Equals("chicken")){
            num_of_chicken += 1;
        }else if(tag.Equals("cow")){
            num_of_cow += 1;
        }else if(tag.Equals("duck")){
            num_of_duck += 1;
        }else if(tag.Equals("pig")){
            num_of_pig += 1;
        }else if(tag.Equals("sheep")){
            num_of_sheep += 1;
        }
        num_of_animals += 1;
    }

    public int getscore()
    {
        int score = 0;
        score = num_of_chicken * 1 + num_of_sheep * 2 + num_of_pig * 3 - num_of_cow * 4 - num_of_duck*5;
        return score;
    }
    
}
