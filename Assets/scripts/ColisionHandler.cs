using UnityEngine;

public class ColisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyed, transform.position, Quaternion.identity);
        Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
