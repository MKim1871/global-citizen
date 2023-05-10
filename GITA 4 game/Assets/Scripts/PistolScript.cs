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
		if (Input.GetButton("Fire2") && !isScoped) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition + new Vector3(-1f, 0.2f, -0.2f), Time.deltaTime * 10f);

			if (transform.localPosition == startingPosition + new Vector3(-0.6f, -0f, -0.6f))
			{
				isScoped = true;
			}
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
		
		if (!isScoped)
		{
			//Restores to original position
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition, Time.deltaTime * 10f);

			isScoped = false;
		}
		
    }
	
	void OnCollisionEnter()
	{
		Destroy(bulletPrefab);
	}
}
