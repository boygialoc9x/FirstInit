using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    Material[] _mats;
    Material _mat;
    Renderer _renderer;
    int _point;
    void Recolor()
    {
        var renderer = GetComponent<Renderer>();
        var length = _mats.Length;
        //renderer.material = _mats[random.range(0, length - 1)];
        var mat = _mats[Random.Range(0, length - 1)];
        _mat = mat;
        renderer.material = mat;
    }

    void Start()
    {
        _point = 0;
        var spawner = GameObject.Find("Spawner");
        _mats = spawner.GetComponent<CubeSpawner>().GetMaterial();
        Recolor();
    }
    void OnCollisionEnter(Collision collision)
    {
        var renderer = GetComponent<Renderer>();
        if(collision.gameObject.CompareTag("Cube"))
        {
            if(collision.gameObject.GetComponent<Collectible>().GetCurrentMaterial() != _mat)
            {
                Loose();
            }
            else
            {
                AddPoint();
            
            }
        }
    }

    void Loose()
    {
    }

    void AddPoint()
    {
        Recolor();
        _point++;
        GetComponent<PlayerMovement>().BoostSpeed(_point);
    }
}
