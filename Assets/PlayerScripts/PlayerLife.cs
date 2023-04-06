using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource _deathSound;
    [SerializeField] GameObject _endGame;
    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();    
        }
    }
    public void Die()
    {
        Disable();
        _deathSound.Play();
        Invoke(nameof(Lose), 1.5f);
    }

    public void Disable()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
    }
    
    void Lose()
    {
        var x = _endGame.GetComponent<PopUp>();
        x.SetMessage("YOU LOSE");
        x.Enable();
    }

    public void Win()
    {
        Disable();
        var x = _endGame.GetComponent<PopUp>();
        x.SetMessage("YOU WIN");
        x.Enable();
    }

}
