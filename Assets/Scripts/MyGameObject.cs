using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyGameObject
{
    public GameObject gameObject;
    public IActivation activation;

    public MyGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.activation = gameObject.GetComponent<IActivation>();
        this.gameObject.SetActive(false);
    }
}
