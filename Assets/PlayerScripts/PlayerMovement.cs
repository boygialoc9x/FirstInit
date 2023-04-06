using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Stats stats;
    private Rigidbody body;
    private Vector3 safePoint;
    [SerializeField] Text _speedText;
    [SerializeField] float _maxSpeed = 50;

    void Start()
    {
        stats = GetComponent<Stats>();
        body = GetComponent<Rigidbody>();
    }

    void UpdateText()
    {
        _speedText.text = "Speed: " + stats.getSpeed();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * stats.getSpeed();
        float trans2 = Input.GetAxis("Horizontal") * stats.getSpeed();
        body.velocity = new Vector3(trans2, body.velocity.y, translation);
        safePoint = transform.position;
        UpdateText();
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
        if(stats.getSpeed() < _maxSpeed)
        {
            stats.AddSpeed(amount);
        }
    }

}
