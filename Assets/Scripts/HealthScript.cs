using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3((MainScript.Player.CurrentHealth/MainScript.Player.MaxHealth),1,1);
	}
}
