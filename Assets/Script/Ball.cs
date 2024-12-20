using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int random;

    [SerializeField]
    public float speed = 5.0f;

    Rigidbody rb;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        random = UnityEngine.Random.Range(0, 3);
        // Ball direction at start
        direction = Vector3.forward * 0.02f;

        ChangeColor();
    }

    void FixedUpdate ()
    {
        RandomManager();

        //rb.AddForce(direction, ForceMode.VelocityChange);
    }

    void ChangeColor ()
    {
        int random = UnityEngine.Random.Range(0, 3);

        switch(random)
        {
            case 0:
                this.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 1:
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 2:
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
        }
    }

    void RandomManager ()
    {
        switch(random)
        {
            case 0:
                //this.transform.position += Vector3.right * speed * Time.fixedDeltaTime;
                rb.AddForce(Vector3.right, ForceMode.VelocityChange);
                break;
            case 1:
                //this.transform.position += Vector3.left * speed * Time.fixedDeltaTime;
                rb.AddForce(Vector3.left, ForceMode.VelocityChange);
                break;
            case 2:
                //this.transform.position += Vector3.down * speed * Time.fixedDeltaTime;
                rb.AddForce(Vector3.down, ForceMode.VelocityChange);
                break;
            case 3:
                //this.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
                rb.AddForce(Vector3.up, ForceMode.VelocityChange);
                break;
        }
    }

    void OnCollisionEnter (Collision coll)
    {
        if(coll.transform.tag == "ball")
        {
            //Rigidbody pushedBody = rb;

            // Get direction from your postion toward the object you wish to push
            //var direction = pushedBody.transform.position - transform.position;

            // Normalization is important, to have constant unit!
            //pushedBody.AddForce(direction.normalized * 500, ForceMode.Force);
   
Vector2 newVelocity = rb.velocity;
newVelocity.x += Mathf.Sign(newVelocity.x) * 2;
rb.velocity = newVelocity;
ChangeColor();
        }

        if(coll.transform.tag == "wall")
        {
           Vector2 newVelocity = rb.velocity;
newVelocity.x += Mathf.Sign(newVelocity.x) * 2;
rb.velocity = newVelocity;
ChangeColor();
        }
    }
}
