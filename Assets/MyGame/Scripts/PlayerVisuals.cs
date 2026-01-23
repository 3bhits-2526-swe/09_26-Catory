using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    [Header("Visuals")]
    public GameObject visualRL; 
    public GameObject visualVR; 

    private Animator animRL;
    private Animator animVR;
    private Rigidbody2D rb;
    private Vector2 movement;

    private Vector3 originalScaleRL;
    private Vector3 originalScaleVR;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (visualRL != null) 
        {
            animRL = visualRL.GetComponent<Animator>();
            originalScaleRL = visualRL.transform.localScale;
        }

        if (visualVR != null) 
        {
            animVR = visualVR.GetComponent<Animator>();
            originalScaleVR = visualVR.transform.localScale;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        bool isMoving = movement.sqrMagnitude > 0;

        if (animRL != null) animRL.SetBool("isMoving", isMoving);
        if (animVR != null) animVR.SetBool("isMoving", isMoving);

        if (moveX > 0)
        {
            FlipVisuals(1);
        }
        else if (moveX < 0)
        {
            FlipVisuals(-1);
        }
    }


    void FlipVisuals(float directionMultiplier)
    {
        if (visualRL != null) 
        {
            visualRL.transform.localScale = new Vector3(
                Mathf.Abs(originalScaleRL.x) * directionMultiplier, 
                originalScaleRL.y, 
                originalScaleRL.z
            );
        }
            
        if (visualVR != null) 
        {
            visualVR.transform.localScale = new Vector3(
                Mathf.Abs(originalScaleVR.x) * directionMultiplier, 
                originalScaleVR.y, 
                originalScaleVR.z
            );
        }
    }
}