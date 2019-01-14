using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    Rigidbody2D playerQ;
    [SerializeField]float speed;
	// Use this for initialization
	void Start () {

        playerQ = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        var dist = (transform.position.y - Camera.main.transform.position.y);

        var leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x * 2.5f;
        //to include spirte body add: +GetComponent<Renderer>().bounds.extents.x;
        var rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x * 2.5f;
        //to include sprite body add: -GetComponent<Renderer>().bounds.extents.x;

        float xInput = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector2 movement = playerQ.position + Vector2.right * xInput;
        movement.x = Mathf.Clamp(movement.x, rightLimitation, leftLimitation);
        playerQ.MovePosition(movement);
       

    }
}
