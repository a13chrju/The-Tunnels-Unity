using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    Animator anim;
    public string message;
    public CanvasGroup canvasText;
    public Text text;
    // Start is called before the first frame update
    bool canInteract = false;
    public bool isItem = false;
    Inventory forPlayer;
    public bool isPlayer = false;

    public bool isDoor = false;
    public bool isDoorOpened = false;
    public GameObject doorBlocker;
    public GameObject door;

    public bool isPickedUp = false;
    public bool isAllowedToTrigger = true;
    Camera _main;
    Transform Cameraunder;

    private GameObject player;
    void Start()
    {
        _main = Camera.main;
        canvasText.alpha = 0;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            if (isPlayer) { 
                Debug.Log("wave");
                anim.SetTrigger("Wave");
            }

            if (isDoor && !isDoorOpened && forPlayer.hasItem("Key")) // add item to pocket
            {
                text.text = "";
                canInteract = false;
                isAllowedToTrigger = false;
                isDoorOpened = true;
                door.GetComponent<Animator>().SetBool("open", true);
                this.GetComponent<Rigidbody>().isKinematic = false;
                doorBlocker.SetActive(false);
                Destroy(this);
                return;
            }

            if (isItem && isPickedUp) // can throw it now
            {
                //   Rigidbody rb = gameObject.AddComponent<Rigidbody>();
                //    rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                this.GetComponent<Rigidbody>().useGravity = true;
                isPickedUp = false;
                canInteract = false;
                StartCoroutine(WaitAndRemoveKey(1));
                this.transform.parent = null;
                Cameraunder = player.GetComponentInChildren<Camera>().transform;
                this.GetComponent<Rigidbody>().AddForce(Cameraunder.forward * 700);
                return;
            }

            if (isItem && !isPickedUp) // add item to pocket
            {
                //    this.GetComponent<Rigidbody>().isKinematic = true;
                //    Destroy(gameObject.GetComponent<Rigidbody>());
                this.GetComponent<Rigidbody>().useGravity = false;
                isPickedUp = true;
                
                forPlayer.AddItem("Key");
                text.text = "[E] to throw";
                return;
            }

        }

        if (isPickedUp)
        {
            // carry relative to the player (camera)
           GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, player.GetComponentInChildren<Camera>().transform.position + player.GetComponentInChildren<Camera>().transform.forward * 2, Time.deltaTime * 10));
            transform.rotation = Quaternion.identity;
            //   Cameraunder = player.GetComponentInChildren<Camera>().transform;
            //  Transform target = Cameraunder;
            // this.transform.parent = target;
            //  this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //  this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
           // GetComponent<Rigidbody>().position = Vector3.Lerp(transform.position, player.GetComponentInChildren<Camera>().transform.position + player.GetComponentInChildren<Camera>().transform.forward * 2, Time.deltaTime * 10);

        }
    }

    private IEnumerator WaitAndRemoveKey(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        forPlayer.removeItem("Key");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDoorOpened && isDoor)
        {
            return;
        }

        if (other.gameObject.tag == "player" && isAllowedToTrigger && other.GetComponent<Inventory>().activePlayer)
        {
            forPlayer = other.GetComponent<Inventory>();
            player = other.gameObject;
            if (!isPickedUp)
            {
                text.text = "[E] " + message;
            }
            canvasText.alpha = 1;
            canInteract = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player" && !isPickedUp && isAllowedToTrigger && other.GetComponent<Inventory>().activePlayer)
        {
            canInteract = false;
            canvasText.alpha = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.transform.parent = null;
            isPickedUp = false;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
