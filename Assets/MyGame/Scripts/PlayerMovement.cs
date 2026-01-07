using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private Rigidbody2D rb;

    Scene currentScene = SceneManager.GetActiveScene();

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(currentScene.name == "Level")
            {
                SceneManager.LoadScene("VR");
            }else
            if(currentScene.name == "VR")
            {
                SceneManager.LoadScene("Level");
            }

        }
        if (Input.GetKeyDown("a"))
        {
            
        }
        if (Input.GetKeyDown("d"))
        {
            
        }
        
    }
}
