using UnityEngine;
using System.Collections;

public class PlayerControls : KillableObject
{
    public float shipMovementSpeed = 0.1f;
    //public WeaponScript[] weapons;

    private Vector3 viewportPos;
    //private Animator anim;

    // Use this for initialization
    void Start()
    {
        killableObject = this.gameObject;
        mainCamera = Camera.main;
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisInput();
        KeepPlayerInBounds();
        FireWeapons();
        //DoDefensiveAction();
    }
    /// <summary>
    /// Used to grab input values from the input manager
    /// </summary>
    private void GetAxisInput()
    {
        MoveHorizontal();
        MoveVertical();
    }

    /// <summary>
    /// Used to get the up vector of the camera and add it to the position of the player so that we are constantly staying infront of the camera
    /// </summary>
    private void MoveVertical()
    {
        Vector3 cameraUpVector = mainCamera.transform.up;
        killableObject.transform.position += cameraUpVector * (Input.GetAxis("ShipVerticalMovement") * shipMovementSpeed);
    }

    /// <summary>
    /// Used to get the right vector of the camera and add it to the position of the player so that we are constantly staying infront of the camera
    /// </summary>
    private void MoveHorizontal()
    {
        Vector3 cameraRightVector = mainCamera.transform.right;
        killableObject.transform.position += cameraRightVector * (Input.GetAxis("ShipHorizontalMovement") * shipMovementSpeed);
        killableObject.transform.rotation = Quaternion.Euler(0, 0, -45f * Input.GetAxis("ShipHorizontalMovement") * Time.deltaTime);
    }
    /// <summary>
    /// Used to keep the player in the camera screen bounds
    /// </summary>
    private void KeepPlayerInBounds()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position); //convert the player's position from world space to viewport space
        viewportPos.x = Mathf.Clamp01(viewportPos.x); //clamp the x value of the players position
        viewportPos.y = Mathf.Clamp01(viewportPos.y); //clamp the y value of the players position
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos); //convert the player's position back to world space from viewport space
    }
    
    /// <summary>
    /// [TESTING METHOD]: This will be updated to call the weapon's fire method
    /// </summary>
    public override void FireWeapons()
    {
        if (Input.GetAxis("FireProjectile") == 1)
        {
            if (fireRate <= 0)
            {
                CreateProjectile();
                fireRate = 0.05f;
            }
            fireRate -= Time.deltaTime;
        }
    }

    //private void DoDefensiveAction()
    //{
    //    if (Input.GetAxisRaw("DefensiveAction") != 0)
    //    {
    //        //Debug.Log(Input.GetAxisRaw("DefensiveAction"));
    //        anim.SetBool("IsDefensiveButtonPressed", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("IsDefensiveButtonPressed", false);
    //    }
    //}

}
