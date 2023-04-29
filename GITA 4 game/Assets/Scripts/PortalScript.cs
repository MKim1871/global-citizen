using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
	public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
		{
			
		}
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		SceneManager.LoadScene("Training Level");
		 Debug.Log("Hi");
	}
}
