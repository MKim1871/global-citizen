using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
		
public class InputManager : MonoBehaviour
{
	private PlayerInput playerInput;
	public PlayerInput.OnFootActions onFoot;
	
	private PlayerMotor motor;
	private PlayerLook look;
	
	private GameObject assaultRifle;
	private GameObject pistol;
	
	void Start()
	{
		assaultRifle = GameObject.Find("Player/Main Camera/Default Guns/Assault Rifle");
		pistol = GameObject.Find("Player/Main Camera/Default Guns/Pistol");
		
		pistol.SetActive(false);
	}
    // Start is called before the first frame update
    void Awake()
    {
	
        playerInput = new PlayerInput();
		onFoot = playerInput.OnFoot;
		motor = GetComponent<PlayerMotor>();
		look = GetComponent<PlayerLook>();
		onFoot.Jump.performed += ctx => motor.Jump();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			assaultRifle.SetActive(true);
			pistol.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Alpha2))
		{
			assaultRifle.SetActive(false);
			pistol.SetActive(true);
		}
	
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the player motor to move using the value from the movement action
		motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
	
	void LateUpdate()
	{
		look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
	}
	private void OnEnable()
	{
		onFoot.Enable();
	}
	private void OnDisable()
	{
		onFoot.Disable();
	}
}
