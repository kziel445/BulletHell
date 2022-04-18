using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 1;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    private Rigidbody2D rb;
    [SerializeField] private Camera mainCamera;
    Vector2 vectorMove;
    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            transform.position = mouseWorldPosition;
        }
        vectorMove.x = Input.GetAxisRaw("Horizontal");
        vectorMove.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + vectorMove * movementSpeed * Time.fixedDeltaTime);
    }
}
