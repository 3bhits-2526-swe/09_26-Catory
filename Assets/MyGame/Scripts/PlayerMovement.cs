using JetBrains.Annotations;
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
    private GameObject[] vrObjects;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        vrObjects = GameObject.FindGameObjectsWithTag("VR");
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
            }
            else if(vrObjects[0].activeSelf == true)
            {
                foreach (GameObject obj in vrObjects)
                {
                    obj.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown("a"))
        {
            rb.AddForceX(force);
        }
        if (Input.GetKeyDown("d"))
        {
            
                }
    }
}
