using UnityEngine;
using System.Collections;

public class GravityTypeWeapon : WeaponScript
{

	// Use this for initialization
	void Start ()
    {
        fireRate = 2f;
        projectile = (GameObject)Resources.Load("Prefabs/Projectiles/Projectile");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //public override void FireWeapons()
    //{
        
    //}
}
