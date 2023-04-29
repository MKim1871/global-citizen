using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
	public GameObject bulletPrefab;
	
	private float bulletSpeed = 30.0f;
	private float recoilAmount = 0.1f;
	private bool isScoped;
	private Vector3 startingPosition;
	

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire2") && isScoped == false) {
			transform.localPosition += new Vector3(-0.03f, 0.01f, -0.01f);
			isScoped = true;
		}
		else if (Input.GetButtonDown("Fire2") && isScoped == true) {
			//Restores to original position
			isScoped = false;
		}
        if (Input.GetButtonDown("Fire1")) {
			// Code to shoot
			Quaternion playerRotation = transform.rotation;
			Quaternion bulletRotation = Quaternion.Euler(playerRotation.eulerAngles.x, playerRotation.eulerAngles.y, playerRotation.eulerAngles.z + 90f);
			
			//Generates and shoots bullet
			GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.2f, 0), bulletRotation);
			bullet.GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;
			
			//Code for recoil
			transform.localPosition += new Vector3(0, 0, -recoilAmount);
			
			//Code for bullet disappearance
		}
		
		transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition, Time.deltaTime * 10f);
		
    }
	
	void OnCollisionEnter()
	{
		Destroy(bulletPrefab);
	}
}
