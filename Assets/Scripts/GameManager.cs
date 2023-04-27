using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    public int LayerToIndex(LayerMask layer)
    {
        int value = layer.value;
        int index = 0;
        while(value > 0)
        {
            index++;
            value >>= 1;
        }
        return index - 1;
    }
}
