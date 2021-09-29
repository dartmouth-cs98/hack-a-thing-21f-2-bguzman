using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret(){
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurret2Build(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher(){
        Debug.Log("Missile Launcher Selected");
        buildManager.SetTurret2Build(buildManager.missileLauncherPrefab);

    }
}
