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
    
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == playerPrefab)
        {
			Scene currentScene = SceneManager.GetActiveScene();
			if(currentScene.name == "SampleScene")
			{
				SceneManager.LoadScene("Training Level");
			}
			else if(currentScene.name == "Training Scene")
			{
				SceneManager.LoadScene("SampleScene");
			}
        }
	}
}
