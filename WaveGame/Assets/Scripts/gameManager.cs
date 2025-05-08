using UnityEngine;

public class gameManager : MonoBehaviour
{
   public static gameManager instance;


    public GameObject player;
    public Transform playerTransform;
    

     void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
