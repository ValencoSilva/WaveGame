using UnityEngine;

public class playerController : MonoBehaviour, IDamage
{
    [SerializeField] CharacterController characterController;

    [SerializeField] int speed;
    [SerializeField] float playerSpeedy;
    [SerializeField] int HP;
    [SerializeField] float gravity;
    [SerializeField] int shootDist;


    int maxHP;
    bool IsGrounding;

    Vector3 moveDir;
    [SerializeField] Vector3 playerVel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        characterController = gameObject.AddComponent<CharacterController>();
        //characterController = gameObject.GetComponent<CharacterController>();
        //characterController = characterController.GetComponent<CharacterController>();
        //characterController = GetComponent<CharacterController>();

        maxHP = HP;
        //gameManager.instance.isNotPaused();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward*shootDist,Color.green);

    }

    void movement()
    {
        //if (characterController.isGrounded)
        //{
        //    playerVel = Vector3.zero;
        //}
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //move = Vector3.ClampMagnitude(move,1f);

        //if (move != Vector3.zero) {
        //    transform.forward = move;

        //}

        //playerVel.y += gravity * Time.deltaTime;

        //Vector3 moveFinal = (move * playerSpeedy) + (playerVel.y * Vector3.up);
        //characterController.Move(moveFinal*Time.deltaTime);

        if (characterController.isGrounded)
        {

            playerVel = Vector3.zero;
        }


        moveDir = (Input.GetAxis("Horizontal") * transform.right) + (Input.GetAxis("Vertical") * transform.forward);

        //transform.position += moveDir *speed * Time.deltaTime;

        characterController.Move(moveDir * speed * Time.deltaTime);



        playerVel.y -= gravity * Time.deltaTime;
        characterController.Move(playerVel * Time.deltaTime);

        gameOver();
        
    }

    void gameOver()
    {
        if (HP <= 0)
        {
            Debug.Log("Bye Bye Bye");
            gameManager.instance.GameOver();

        }
    }

    public void takeDamage(int amount)
    {
        HP -= amount;
        updateHP();
    }

    
    void updateHP()
    {
        gameManager.instance.healthBar.fillAmount = (float)HP / maxHP; //hp =50 and maxhp = 50 -> 50/50=1 ///// hp = 25 and maxhp = 50 -> 25/50 = 0.5
    }
}