using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Material _mat;
    public void setMaterial(Material material)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material = material;
        _mat = material;
    }

    public Material GetCurrentMaterial()
    {
        //var renderer = GetComponent<Renderer>();
        //return renderer.material;
        return _mat;
    }

    Vector2 _rangeX, _rangeY, _rangeZ;

    public void setRange(Vector2 rangeX, Vector2 rangeY, Vector2 rangeZ)
    {
        _rangeX = rangeX;
        _rangeY = rangeY;
        _rangeZ = rangeZ;
    }
    void Start()
    {
        Respawn();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float xRange = Random.Range(_rangeX.x, _rangeX.y);
        float y = Random.Range(_rangeY.x, _rangeY.y); 
        float zRange = Random.Range(_rangeZ.x, _rangeZ.y); 
        transform.position = new Vector3(xRange, y, zRange);
    }
}
