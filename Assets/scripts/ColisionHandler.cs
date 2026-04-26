using UnityEngine;

public class ColisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyed;

    // making a reference to a gamescenemanager

    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindAnyObjectByType<GameSceneManager>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(playerDestroyed, transform.position, Quaternion.identity);
        //Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
