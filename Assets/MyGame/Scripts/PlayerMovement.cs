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
    private GameObject[] vrObjects;
    private GameObject[] realObjects;

    void Start()
    {
        tf = player.GetComponent<Transform>();
        vrObjects = GameObject.FindGameObjectsWithTag("VR");
        realObjects = GameObject.FindGameObjectsWithTag("RL");
    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(vrObjects[0].activeSelf == false)
            {
                foreach (GameObject obj in vrObjects)
                {
                    obj.SetActive(true);
                }
                foreach (GameObject obj in realObjects)
                {
                    obj.SetActive(true);
                }
            }
            else if(vrObjects[0].activeSelf == true)
            {
                foreach (GameObject obj in vrObjects)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in realObjects)
                {
                    obj.SetActive(false);
                }
            }
        }
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
