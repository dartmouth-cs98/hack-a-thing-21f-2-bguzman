using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour{

    public static BuildManager instance;

    void Awake(){
        if (instance != null){
            Debug.LogError("more than 1 BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private GameObject turret2Build;

    public GameObject GetTurret2Build(){
        return turret2Build;
    }

    public void SetTurret2Build(GameObject Turret){
        turret2Build = Turret;
    }
}
