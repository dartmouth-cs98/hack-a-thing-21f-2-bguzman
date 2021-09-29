using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurret2Build() == null){
            return;
        }

        if (turret != null){
            //to do: display on screen
            Debug.Log("Can't build there");
            return;
        }
        //build a turret
        GameObject turret2Build = buildManager.GetTurret2Build();
        turret = (GameObject )Instantiate(turret2Build, transform.position + positionOffset, transform.rotation);
        
    }

    void OnMouseEnter(){
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurret2Build() == null){
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit(){
        rend.material.color = startColor;
    }
}

