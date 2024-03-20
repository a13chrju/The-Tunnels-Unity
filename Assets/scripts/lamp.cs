using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lamp;
    public bool turnedOn = false;
    void Start()
    {
        Lamp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            turnedOn = !turnedOn;
            Lamp.SetActive(turnedOn);
        }
    }
}
