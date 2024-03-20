using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 4f; Camera _main;
    float moveHorizontal, moveVertical; Vector3 movHorizontal, movVertical;
    float MaxSlopeAngle = 60;
    public Transform raycastOrigin;

    void Start()
    {
        _main = Camera.main;
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * -1f; //Joystick.Horizontal
        moveVertical = Input.GetAxisRaw("Vertical") * -1f; // Joystick.Vertical
        movHorizontal = (transform.right * moveHorizontal) * -1f;
        movVertical = (transform.forward * moveVertical) * -1f;

        Vector3 Velocity = ((movHorizontal + movVertical).normalized) * m_Speed;
        m_Rigidbody.MovePosition(m_Rigidbody.position + Velocity * Time.fixedDeltaTime);

        Vector3 offset = new Vector3(0, Input.GetAxis("Mouse X") * 4, 0);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * Quaternion.Euler(offset));
    }
}

