using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public GameObject Player;

    float MaxDist = 2f;

    public Animator Enemyani;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //On Spawn Focus Player
        Enemy.SetDestination(Player.transform.position);
        //when near or far from player
        FocusingPlayer();
    }

    void FocusingPlayer()
    {
        //near player
        if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
        {
            Enemy.isStopped = true;
            Enemyani.SetTrigger("Attack");
        }
        //not near player
        else if (Vector3.Distance(transform.position, Player.transform.position) >= MaxDist)
        {
            Enemy.isStopped = false;
            Enemy.SetDestination(Player.transform.position);
            Enemyani.SetBool("Walk", true);
        }
    }

}
