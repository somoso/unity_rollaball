using UnityEngine;
using System.Collections;

public class RespawnArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int x = Random.Range(-18, 18);
        int z = Random.Range(-18, 18);
        transform.position = new Vector3(x/2.0f, 0.5f, z/2.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
