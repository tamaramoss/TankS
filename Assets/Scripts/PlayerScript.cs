using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;
    private Rigidbody rb;
    private GameObject top;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        top = gameObject.transform.Find("Top").gameObject;
    }

    public void OnMoveTank(InputAction.CallbackContext context)
    {
        var readValue = context.ReadValue<Vector2>();
        
        if (readValue.y != 0.0f)
        {
            var moveForce = transform.forward * readValue.y * playerSpeed;
            //transform.Translate(moveForce);
            rb.AddForce(moveForce);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (readValue.x != 0.0f)
        {
            var rotationForce = Vector3.up * readValue.x *  playerSpeed;
            //transform.Rotate(rotationForce);
            rb.AddTorque(rotationForce);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
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
        var mousePos = context.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        
        if (Physics.Raycast(ray, out var hit)) {
            Vector3 hitPoint = new Vector3(hit.point.x, GameManager.Instance.SpawnHeight, hit.point.z);

            if (Vector3.Distance(transform.position, hitPoint) > 5)
            {
                top.transform.LookAt(hitPoint);

            }    
            
        }   
    }
}

