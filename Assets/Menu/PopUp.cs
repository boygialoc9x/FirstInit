using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Text _endGameMessage;
    //GameObject _target;
    [SerializeField] GameObject _target;
    void Start()
    {
        Disable();
        //_target = gameObject;
    }

    public void Disable()
    {
        _target.SetActive(false);

    }
    public void Enable()
    {
        _target.SetActive(true);
    }

    public void SetMessage(string message)
    {
        _endGameMessage.text = message;
    }

}
