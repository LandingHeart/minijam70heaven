using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene2");
    }
}
