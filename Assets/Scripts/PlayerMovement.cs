using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    [SerializeField] private Rigidbody rb;
    [SerializeField] static public float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 360;
    public bool isOnGround = true;
    public float jumpForce = 5;
    public Vector3 input;
    private Animator animator;
    public InventoryObject inventory;
    public bool canMove = true;
   
    void Start()
    {
        animator = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>(); // Assuming you are using a Rigidbody for movement
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        
        GatherInput();
        Look();
        animator.SetBool("isMoving", input != Vector3.zero);
        animator.SetBool("isGrounded", isOnGround);
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (input == Vector3.zero) return;

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        var skewedInput = matrix.MultiplyPoint3x4(input);

        var relative = (transform.position + skewedInput) - transform.position;
        var rotation = Quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

     /**public void StopMovement()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Reset velocity to stop movement immediately
        }

        // If you're using a CharacterController, you could reset its movement vector here
    }**/
}

