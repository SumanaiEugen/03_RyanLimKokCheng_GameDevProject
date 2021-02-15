using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;

    float MaxDist = 2f;

    public Animator Enemyani;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //target player position
        Enemy.SetDestination(Player.position);

        //near player
        if(Vector3.Distance(transform.position,Player.position) <= MaxDist)
        {
            Enemy.isStopped = true;
            Enemyani.SetTrigger("Attack");
        }
        //not near player
        else if(Vector3.Distance(transform.position, Player.position) >= MaxDist)
        {
            Enemy.isStopped = false;
            Enemy.SetDestination(Player.position);
            Enemyani.SetBool("Walk", true);
        }
    }
    /*
    IEnumerator AfterAttack()
    {
        yield return new WaitForSeconds(2);
        Enemy.isStopped = false;
        Enemy.SetDestination(Player.position);
        Enemyani.SetBool("Walk", true);
    
    }
    */
}
