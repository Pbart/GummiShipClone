using UnityEngine;
using System.Collections;

public class EnemyFireScript : KillableObject
{

    void Start()
    {
        killableObject = this.gameObject;
        mainCamera = Camera.main;
    }

    void Update()
    {
        FindPlayer();
        FireWeapons();
    }
    
    void FindPlayer()
    {
        killableObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public override void CreateProjectile()
    {
        GameObject clone = (GameObject)Instantiate(projectile, killableObject.transform.position, killableObject.transform.rotation);
        clone.transform.parent = (mainCamera.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
