using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class changeUser : MonoBehaviour
{
    // Start is called before the first frame update
    bool notAlex = true; // 0 == sphere, 1 = alex
    public GameObject Alex;
    public GameObject Chris;

    public GameObject Alex_camera;
    public GameObject Chris_camera;

    public GameObject Alex_light;
    public GameObject Chris_light;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            notAlex = !notAlex;
            Debug.Log(notAlex);

            if (notAlex) // e.g Chris
            {
                Chris.GetComponent<move>().enabled = true;
                Chris.GetComponent<agenMove>().enabled = false;
                Chris.GetComponent<NavMeshAgent>().enabled = false;

                Chris_camera.GetComponent<Camera>().enabled = true;
                Alex_camera.GetComponent<Camera>().enabled = false;

                Alex.GetComponent<move>().enabled = false;
                Alex.GetComponent<agenMove>().enabled = true;
                Alex.GetComponent<NavMeshAgent>().enabled = true;

                Alex.GetComponent<Interact>().isAllowedToTrigger = true;
                Alex.GetComponent<Interact>().enabled = true;
                Chris.GetComponent<Interact>().isAllowedToTrigger = false;
                Chris.GetComponent<Interact>().enabled = false;

                foreach (Renderer r in Chris.GetComponentsInChildren<SkinnedMeshRenderer>())
                  r.enabled = false;

                foreach (Renderer r in Alex.GetComponentsInChildren<SkinnedMeshRenderer>())
                    r.enabled = true;

                Alex_light.GetComponent<Light>().enabled = false;
                Chris_light.GetComponent<Light>().enabled = true;

                Chris.GetComponent<Inventory>().activePlayer = true;
                Alex.GetComponent<Inventory>().activePlayer = false;
            }
            else // e.g Alex
            { 
                Chris.GetComponent<move>().enabled = false;
                Chris.GetComponent<NavMeshAgent>().enabled = true;
                Chris.GetComponent<agenMove>().enabled = true;

                Alex_camera.GetComponent<Camera>().enabled = true;
                Chris_camera.GetComponent<Camera>().enabled = false;

                Alex.GetComponent<agenMove>().enabled = false;
                Alex.GetComponent<NavMeshAgent>().enabled = false;
                Alex.GetComponent<move>().enabled = true;
                Alex.GetComponent<Interact>().isAllowedToTrigger = false;
                Alex.GetComponent<Interact>().enabled = false;
                Chris.GetComponent<Interact>().isAllowedToTrigger = true;
                Chris.GetComponent<Interact>().enabled = true;

                foreach (Renderer r in Alex.GetComponentsInChildren<SkinnedMeshRenderer>())
                    r.enabled = false;

                foreach (Renderer r in Chris.GetComponentsInChildren<SkinnedMeshRenderer>())
                    r.enabled = true;

                Alex_light.GetComponent<Light>().enabled = true;
                Chris_light.GetComponent<Light>().enabled = false;

                Alex.GetComponent<Inventory>().activePlayer = true;
                Chris.GetComponent<Inventory>().activePlayer = false;
            }
        }   

    }
}
