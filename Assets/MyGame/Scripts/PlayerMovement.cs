using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            
        }
        if (Input.GetKeyDown("d"))
        {
            
        }
    }
}
