using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 15f;
    private Transform target;
    public Transform part2Rotate;
    public float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortedDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies )
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortedDistance){
                shortedDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortedDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){return;}

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(part2Rotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        part2Rotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
