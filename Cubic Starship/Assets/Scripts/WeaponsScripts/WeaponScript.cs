using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;

    private int numberOfDirections;
    private Vector3 directionToFire;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        FireWeapons();
	}
    public virtual void CreateProjectile()
    {
        GameObject projectileClone = (GameObject)Instantiate(projectile, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
        projectileClone.transform.SetParent(this.transform.parent);
    }

    public virtual void FireWeapons()
    {
        if (fireRate <= 0)
        {
            CreateProjectile();
            fireRate = 2f;
        }
        fireRate -= Time.deltaTime;
    }
}
