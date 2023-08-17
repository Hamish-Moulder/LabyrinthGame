using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class RotatePlaneScript : MonoBehaviour
{
    public float moveSpeed = 20;
    public float maxAngle = 20;

    private float rotationX = 0f;
    private float rotationZ = 0f;


    Gyroscope m_Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    private void FixedUpdate()
    {

       

        //Generate a x and z velocity.
        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");

        rotationX += ((moveSpeed * y) * Time.deltaTime);

        rotationX = Mathf.Clamp(
            value: rotationX, 
            min: -maxAngle,
            max: maxAngle
            );

        rotationZ -= ((moveSpeed * x) * Time.deltaTime);

        rotationZ = Mathf.Clamp(
            value: rotationZ,
            min: -maxAngle,
            max: maxAngle
        );

        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, rotationZ);




        // Input.GetAxis will produce three possible numbers: -1, 0 , 1
        // -1 can indicates a neagative push on that axis. for exmple left / a
        // 0 represents no change on the axis.
        // 1 indicates a positive push on that axis. for example right / d

        // if we mutiply the move speed by that axis change it will result in a movement velocity.
        // for example:
        // 20 * -1 = -20
        // 20 * 0 = 0
        // 20 * 1 = 20

        // rotationX += ((moveSpeed * y) * Time.deltaTime);
        // rotationZ -= ((moveSpeed * x) * Time.deltaTime);

        // below will just clamp the objects roation on both the
        // X and Z axis to a set angle in both a pos and neg direction.
        // rotationX = Mathf.Clamp(rotationX, -maxAngle, maxAngle);
        // rotationZ = Mathf.Clamp(rotationZ, -maxAngle, maxAngle);


        // we then set the angle of the object.
    }

    /*private void Update()
    {
        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");

        //change the x & z rotaion.
        rotationX += ((moveSpeed * y) * Time.deltaTime);

        rotationZ -= ((moveSpeed * x) * Time.deltaTime);

        // clamp or restrict the values (x & z) between min and a max.
        rotationX = Mathf.Clamp(rotationX, -maxAngle, maxAngle);

        rotationZ = Mathf.Clamp(rotationZ, -maxAngle, maxAngle);

        // apply the rotation to the transform of object.
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, rotationZ);
    }*/

}
