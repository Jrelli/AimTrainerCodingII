using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {
    //public Camera cam;
    [Tooltip("A multiplier to the input. Describes the maximum speed in degrees/second. To flip vertical rotation, set Y to negative value")]
    [SerializeField]private Vector2 sensitivity;
    private float maxYValue = 85f;

    private Vector2 rotation; //Current rotation in degrees

    private float clampVeticalAngle(float angle){
        return (Mathf.Clamp(angle, -maxYValue, maxYValue));
    }

    private Vector2 GetInput(){
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        return(input);
    }

    //called once every frame or smth like that idk
    private void Update(){
        //current input scaled by the sensitivity and the maximum velocity
        Vector2 wantedVelocity = GetInput() * sensitivity;

        //calculate new rotation
        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = clampVeticalAngle(rotation.y);

        //convert the rotation to euler angles
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
