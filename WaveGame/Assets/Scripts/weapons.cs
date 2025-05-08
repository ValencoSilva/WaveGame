using UnityEngine;
using System.Collections;

public class weapons : MonoBehaviour
{
    enum Weapons{
        Sword,
        Staff,
        Bow,
        Enemies
    }

    [SerializeField] Weapons weaponsType;

    [SerializeField] int damageAmount;
    [SerializeField] float damageRate;


    bool isDamaging;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    //Staff,bow and sword
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }
    }


    //enemies
    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        IDamage dmg = other.GetComponent<IDamage>();
        if (dmg !=null&&weaponsType==Weapons.Enemies)
        {
            if (!isDamaging) {
                StartCoroutine(damageOther(dmg));
            }
        }


    }

  
    IEnumerator damageOther(IDamage d)
    {

        isDamaging = true;
        d.takeDamage(damageAmount);
        Debug.Log("Took damage");
        yield return new WaitForSeconds(damageRate);
        isDamaging = false;
    }
   
    
}
