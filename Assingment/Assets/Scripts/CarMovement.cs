using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class CarMovement : MonoBehaviour
{

    public float speed = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Drive(float units)
    {
        Vector3 forward = transform.forward;
        //forward.y = 0;
        forward.Normalize();
        transform.position += forward * units;

    }

    // Update is called once per frame
    void Update()
    {
        float contDrive = Input.GetAxis("Vertical");
        Drive(speed * Time.deltaTime);
    }
}
