using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool isGrounded;
	private float speed = 5f;
	private float gravity = -9.8f;
	private float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
	
	//Receives inputs from InputManager.cs and applies them to controller
	public void ProcessMove(Vector2 input)
	{
		Vector3 moveDirection = Vector3.zero;
		//allows left or right movement, is z and not y because y is up
		moveDirection.x = input.x;
		moveDirection.z = input.y;
		controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
		playerVelocity.y += gravity * Time.deltaTime;
		
		if(isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = -2f;
		}
		
		controller.Move(playerVelocity * Time.deltaTime);
		Debug.Log(playerVelocity.y);
	}
	
	public void Jump()
	{
		if(isGrounded)
		{
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
		}
	}
}
