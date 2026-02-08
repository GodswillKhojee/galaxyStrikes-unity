using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xclampedrange = 2f;
    [SerializeField] float yclampedrange = 2f;
    [SerializeField] float rotationSpeed = 15f;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 18f;

    Vector3 movement;
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    public void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void ProcessTranslation()
    {
        float xoffset = movement.x * controlSpeed * Time.deltaTime;
        float rawxpos = transform.localPosition.x + xoffset;
        float xclampedpos = Mathf.Clamp(rawxpos,-xclampedrange,xclampedrange);
            
        float yoffset = movement.y * controlSpeed * Time.deltaTime;
        float rawypos = transform.localPosition.y + yoffset;
        float yclampedpos = Mathf.Clamp(rawypos, -yclampedrange,yclampedrange);


        transform.localPosition = new Vector3(xclampedpos,yclampedpos,0f);
    }

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch,0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation,rotationSpeed * Time.deltaTime);

     
    }
}
