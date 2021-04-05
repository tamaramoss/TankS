using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;    
    public float aimSpeed;

    private Rigidbody rb;
    private Transform topRb;
    private Camera main;
    private Vector3 readMoveValue;
    private Vector2 readMouseValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        topRb = transform.Find("Top");
        main = Camera.main;
    }

    private void FixedUpdate()
    {

        ApplyMovement();
        ApplyAim();
    }

    public void OnMoveTank(InputAction.CallbackContext context)
    {
        readMoveValue = context.ReadValue<Vector2>();
        //Debug.Log(readMoveValue);
    }

    private void ApplyMovement()
    {
        var wantedVelocity = transform.forward * (readMoveValue.y * playerSpeed * Time.fixedDeltaTime);
        rb.AddForce(wantedVelocity);
        
        var wantedRotationForce = Vector3.up * (readMoveValue.x * rotationSpeed * Time.fixedDeltaTime);
        rb.AddTorque(wantedRotationForce);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        
        StartCoroutine("Shoot");
        SpawnPools.Instance.SpawnFromPool(GetProjectileName(context.action.ToString()),
            transform.Find("Top").Find("ProjectileSpawnPosition"));
    }

    private string GetProjectileName(string actionString)
    {
        // The action string looks like this:
        // action=PlayerTank/ShootMain[/Mouse/leftButton]
        // So I named the pools like the action, here "ShootMain" 
        // so I don't have to make an extra method for every projectile type

        var startIdx = actionString.IndexOf('/');
        return actionString.Substring( startIdx + 1,
            (actionString.IndexOf('[') - startIdx) - 1);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        readMouseValue = context.ReadValue<Vector2>();
    }

    private void ApplyAim()
    {
        Ray ray = main.ScreenPointToRay(readMouseValue);
        Quaternion targetRotation;
        Quaternion currentRotation = topRb.rotation;
        Vector3 hitPoint = Vector3.zero;
        RaycastHit hit;
 
        if (Physics.Raycast(ray, out hit))
        {
            hitPoint = new Vector3(hit.point.x, GameManager.Instance.SpawnHeight, hit.point.z);
            targetRotation = Quaternion.LookRotation(hitPoint - topRb.position);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(ray.direction);
        }
        float angularDifference = Quaternion.Angle(currentRotation, targetRotation);
        if (angularDifference > 0 /*&& Vector3.Distance(transform.position, hitPoint) > 5*/)
        {
            Debug.Log(targetRotation);
            var newR = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
            topRb.rotation = Quaternion.RotateTowards(topRb.rotation, newR, aimSpeed * Time.fixedDeltaTime);
            // topRb.rotation = Quaternion.Slerp
            // (
            //     topRb.rotation,
            //     targetRotation,
            //     aimSpeed * Time.fixedDeltaTime
            // );
            
        }
        // else
        // {
        //     topRb.rotation = targetRotation;
        // }
        
        // if (Physics.Raycast(ray, out var hit)) {
        //     Vector3 hitPoint = new Vector3(hit.point.x, GameManager.Instance.SpawnHeight, hit.point.z);
        //
        //     if (Vector3.Distance(transform.position, hitPoint) > 5)
        //     {
        //         topRb.LookAt(hitPoint);
        //     }
        // } 
    }
} 

