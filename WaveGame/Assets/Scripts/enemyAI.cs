using UnityEngine;

public class enemyAI : MonoBehaviour , IDamage
{
    [SerializeField] float speed;
   
    Transform playerTarget;
    Vector3 enemyPos;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTarget = gameManager.instance.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer();
    }

    void targetPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speed/5);
    }

    public void takeDamage(int amount)
    {
          
    }
}
