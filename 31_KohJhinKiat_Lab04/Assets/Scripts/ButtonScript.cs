using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartButton()
    {
        SceneManager.LoadScene("GamePlay_Level 1");
    }

    public void nextLevelButton()
    {
        SceneManager.LoadScene("GamePlay_Level 2");
    }



}
