using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public GameObject bullet;
    public float bulletSpeed = 5.0f;

    public float shootDelay = 0.1f;

    private bool canShoot = true;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 shootDirection = Vector3.right * Input.GetAxis(horizontalAxis) + Vector3.forward * Input.GetAxis(verticalAxis);
        if (canShoot && shootDirection.sqrMagnitude > 0.0f) {
            transform.rotation = Quaternion.LookRotation(shootDirection, Vector3.up);
            Instantiate(bullet, transform.position, transform.rotation);
            canShoot = false;
            Invoke("resetShoot", shootDelay);
        }
	}
    void resetShoot()
    {
        if(!canShoot)
            canShoot = true;
    }
}
