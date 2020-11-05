using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button button01;
    public Button button02;

    // Start is called before the first frame update

    
    
    void Start()
    {
        this.button01.onClick.AddListener(playClicked01);
        this.button02.onClick.AddListener(playClicked02);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClicked01()
    {
        SceneManager.LoadScene("Midterm Project");
    }

    public void playClicked02()
    {
        SceneManager.LoadScene("Menu");
    }
}
