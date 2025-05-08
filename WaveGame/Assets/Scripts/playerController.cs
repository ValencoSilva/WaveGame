using UnityEngine;

public class playerController : MonoBehaviour , IDamage
{
    [SerializeField] CharacterController characterController;

    [SerializeField] float playerSpeedy;
    [SerializeField] int HP;
    [SerializeField] float gravity;

    int maxHP;

    [SerializeField] Vector3 playerVel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        characterController = gameObject.AddComponent<CharacterController>();
        //characterController = gameObject.GetComponent<CharacterController>();
        //characterController = characterController.GetComponent<CharacterController>();
        //characterController = GetComponent<CharacterController>();

        maxHP = HP;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move,1f);

        if (move != Vector3.zero) {
            transform.forward = move;//??
            //Debug.Log("??");
        }

        playerVel.y += gravity * Time.deltaTime;

        Vector3 moveFinal = (move * playerSpeedy) + (playerVel.y * Vector3.up);
        characterController.Move(moveFinal*Time.deltaTime);

        gameOver();
    }

    void gameOver()
    {
        if (HP <= 0)
        {
            Debug.Log("Bye Bye Bye");
            
        }
    }

    public void takeDamage(int amount)
    {
        HP -= amount;
    }
}
