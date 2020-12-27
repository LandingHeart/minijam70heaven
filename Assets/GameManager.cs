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

    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
