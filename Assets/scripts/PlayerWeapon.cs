using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetpoint;
    [SerializeField] float targetdistance = 100f;
    bool isfiring = false;

   public void OnFire(InputValue value)
    {
        isfiring = value.isPressed;
    }

     void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        processfire();
        MoveCrosshair();
        movetargetpoint();
        AimLasers();
    }

    void processfire()
    {
        foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isfiring;
        }
    }
    
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void movetargetpoint()
    {
        Vector3 targetpointposition = new Vector3(Input.mousePosition.x,Input.mousePosition.y
            ,targetdistance );
        targetpoint.position = Camera.main.ScreenToWorldPoint( targetpointposition );
    }

    void AimLasers()
    {
        foreach( var laser in lasers )
        {
        Vector3 fireDirection = targetpoint.position - this.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation( fireDirection );
        laser.transform.rotation = rotationToTarget;
        }    
    }
}
