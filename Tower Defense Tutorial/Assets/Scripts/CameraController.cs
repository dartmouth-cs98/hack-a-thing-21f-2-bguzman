using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    //public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;

    public float minY = 10;
    public float maxY = 80;

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w") ){//){
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //new Vector3(0f,0f,1f)
        }
        if (Input.GetKey("s") ){//){
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); //new Vector3(0f,0f,1f)
        }
        if (Input.GetKey("d") ){//){
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); //new Vector3(0f,0f,1f)
        }
        if (Input.GetKey("a") ){//){
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); //new Vector3(0f,0f,1f)
        }

        float scroll  = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 pos = transform.position;

        pos.y  -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);


        transform.position = pos;







    }
}
