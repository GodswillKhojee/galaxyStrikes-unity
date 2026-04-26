using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    private void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<musicPlayer>(FindObjectsSortMode.None).Length;
        if(numOfMusicPlayers > 1 ) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
