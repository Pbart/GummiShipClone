using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour
{
    private GameObject playerShip;
    public GameObject projectile;
    private Vector3 moveDirection;
    private Vector3 viewportPos;
    private float nextTimeToShoot = 0;
    private float getMoveSpeed = 0.001f;
    public float shipMovementSpeed = 5;
    public int radiusFromCamera = 10;

    // Use this for initialization
    void Start()
    {
        playerShip = this.gameObject;
        moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisInput();
        KeepPlayerInBounds();
        FireShipsWeapon();
    }
    /// <summary>
    /// Used to grab input values from the input manager
    /// </summary>
    private void GetAxisInput()
    {
        //moveDirection.x = Input.GetAxis("ShipHorizontalMovement");
        //moveDirection.y = Input.GetAxis("ShipVerticalMovement");
        MoveHorizontal();
        MoveVertical();
    }

    /// <summary>
    /// Used to get the up vector and add it to the position of the player so that we are constantly staying infront of the camera
    /// </summary>
    void MoveVertical()
    {
        Vector3 d = Camera.main.transform.up;
        playerShip.transform.position += d * (Input.GetAxis("ShipVerticalMovement") * shipMovementSpeed);
    }

    /// <summary>
    /// Used to get the right vector and add it to the position of the player so that we are constantly staying infront of the camera
    /// </summary>
    void MoveHorizontal()
    {
        Vector3 d = Camera.main.transform.right;
        playerShip.transform.position += d * (Input.GetAxis("ShipHorizontalMovement") * shipMovementSpeed);
    }
    /// <summary>
    /// Used to keep the player in the camera screen bounds
    /// </summary>
    private void KeepPlayerInBounds()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position); //convert the player's position from world space to viewport space
        pos.x = Mathf.Clamp01(pos.x); //clamp the x value of the players position
        pos.y = Mathf.Clamp01(pos.y); //clamp the y value of the players position
        transform.position = Camera.main.ViewportToWorldPoint(pos); //convert the player's position back to world space from viewport space
    }

    /// <summary>
    /// [TESTING METHOD]: Used to spawn projectiles and set them as a child of the ship so that they move with the ship as it moves
    /// </summary>
    void BulletCreation()
    {
        GameObject projectileClone = (GameObject)Instantiate(projectile, this.transform.position + new Vector3(0,-0.5f,0), transform.rotation);
        projectileClone.transform.SetParent(this.transform.parent);
    }
    /// <summary>
    /// [TESTING METHOD]: Used to fire projectiles from the ship's weapons at a set rate of fire (0.1 as of now). 
    /// Going to rewrite to called the weapon's fire method
    /// </summary>
    void FireShipsWeapon()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if (nextTimeToShoot <= 0)
            {
                BulletCreation();
                nextTimeToShoot = 0.1f;
            }
            nextTimeToShoot -= Time.deltaTime;
        }
    }
    
}
