using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Transform tf;
    public float force = 1f;
    Scene currentScene;

    void Start()
    {
        tf = player.GetComponent<Transform>();
        
    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            tf.Translate(new Vector2(0f, force));
        }
        if (Input.GetKey("d"))
        {
            tf.Translate(new Vector2(0f, -force));
        }
    }    
    
}
