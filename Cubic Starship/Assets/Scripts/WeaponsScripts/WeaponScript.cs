using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;

    private float hiddenFireRate;
    private int numberOfDirections;
    private Vector3 directionToFire;

	// Use this for initialization
	void Start ()
    {
        hiddenFireRate = fireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //FireWeapons();
	}
    public virtual void CreateProjectile()
    {
        GameObject projectileClone = (GameObject)Instantiate(projectile, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
        projectileClone.transform.SetParent(Camera.main.transform);
       // Debug.Log(projectileClone.name);
    }

    public virtual void FireWeapons()
    {
        if (fireRate <= 0)
        {
            CreateProjectile();
            fireRate = hiddenFireRate;
            //Debug.Log("Shooting from the weapons class");
        }
        fireRate -= Time.deltaTime;
    }
    public virtual void TestingFiring()
    {
        Debug.Log("BANG!!!");
    }
}
