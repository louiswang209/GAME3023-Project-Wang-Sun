using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000)]
    private float MoveSpeed = 10.0f;

    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");    
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 oldPosition = transform.position;
        Vector3 velocity = new Vector3(xInput, yInput, 0) * MoveSpeed;

        animator.SetFloat("Horizontal", xInput);
        animator.SetFloat("Vertical", yInput);
        animator.SetFloat("Speed", velocity.sqrMagnitude);

        rigidbody.MovePosition(oldPosition + velocity * Time.deltaTime);
       // transform.position = oldPosition + new Vector3(xInput, yInput, 0) * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Triggered with: " + collision.gameObject.name);
    }
}
