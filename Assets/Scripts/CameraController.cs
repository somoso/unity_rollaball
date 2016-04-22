using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    public bool rip;

    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        rip = false;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!rip) {
            transform.position = player.transform.position + offset;
        } else
        {
            Vector3 currentPos = transform.position;
            Vector3 idealPos = new Vector3(0, 0, -15);
            transform.position = Vector3.SmoothDamp(currentPos, idealPos, ref velocity, 0.1f);
        }
	}
}
