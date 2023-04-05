using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Stats stats;
    private Rigidbody body;
    private Vector3 safePoint;

    void Start()
    {
        stats = GetComponent<Stats>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * stats.getSpeed();
        float trans2 = Input.GetAxis("Horizontal") * stats.getSpeed();
        body.velocity = new Vector3(trans2, body.velocity.y, translation);
        safePoint = transform.position;
        LooseDetect();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //body.velocity = Vector3.zero;
            //body.angularVelocity = Vector3.zero;
            transform.position = safePoint;
        }
    }

    public void BoostSpeed(float amount)
    {
        stats.AddSpeed(amount);
    }
    void Loose()
    {
        print("LOOSEE");
    }

    void LooseDetect()
    {
        if(transform.position.y < 0)
        {
            Loose();
        }
    }

}
