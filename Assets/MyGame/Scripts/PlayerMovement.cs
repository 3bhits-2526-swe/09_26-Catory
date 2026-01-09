using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private float force = 10f;

    Scene currentScene;


    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

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
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-force, 0f));
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(force, 0f));
        }
    }
    
}
