using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController PlayerController;
    public float Speed = 10f;
    public float Gravity = -9.18f;
    Vector3 Velocity;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public float JumpHeight = 3f;
    bool IsGrounded;
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        GravityChange();
        Grounded();
        Jumping();
    }
    void PlayerMovement()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 Move = transform.right * X + transform.forward * Z;

        PlayerController.Move(Move * Speed * Time.deltaTime);
    }
    void GravityChange()
    {
        Velocity.y += Gravity * Time.deltaTime;
        PlayerController.Move(Velocity * Time.deltaTime);
    }
    
    void Grounded()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (IsGrounded && Velocity.y <= 0)
        {
            Velocity.y = -2f;
        }
    }

    void Jumping()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }    

    }
}
