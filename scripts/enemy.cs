using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour {
    private NavMeshAgent navMesh;
    private Player player;
    private float currentDistancePlayer;
    private Vector3 playerPosition;
    private float distanceToFllow = 7f;
    private float distanceToAttack = 1.3f;
    private bool follow;
    private bool attack = false;

    private bool die = false;

    public bool hitAnimator = false;

    public int vida = 2;

    private AudioSource audioSource;
    public AudioClip stopped;
    public AudioClip running;

    private UI ui;

    

    private Animator animator;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        player = FindObjectOfType(typeof(Player)) as Player;
        audioSource = GetComponent<AudioSource>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Player.varPause == false)
        {
            followPlayer();
            attackPlayer();
            enemyDie();
            animator.SetBool("hitAnimator", hitAnimator);
        }
        
    }

    void followPlayer()
    {
        playerPosition = player.transform.position;
        currentDistancePlayer = Vector3.Distance(transform.position, playerPosition);

        if (die == false)
        {
            if (currentDistancePlayer < distanceToFllow)
            {
                follow = true;
                navMesh.SetDestination(playerPosition);
            }
            else
            {
                follow = false;
                navMesh.SetDestination(transform.position);
            }
            animator.SetBool("follow", follow);
        }
    }

    void attackPlayer()
    {
        playerPosition = player.transform.position;
        currentDistancePlayer = Vector3.Distance(transform.position, playerPosition);

        if (die == false)
        {
            if (currentDistancePlayer < distanceToAttack)
            {
                navMesh.SetDestination(transform.position);
                attack = true;
                
            }
            else
            {
                attack = false;
            }
            animator.SetBool("attack", attack);
            
        }
    }

    public void enemyDie()
    {
       if(vida == 0) { 
            navMesh.SetDestination(transform.position);
            die = true;
            animator.SetBool("die", die);
            follow = false;
            Player.points += 15;
            
            ui.updatePoints(Player.points);
            animator.SetBool("follow", follow);
            StartCoroutine(waitDie());
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            die = true;
            animator.SetBool("die", die);
            follow = false;
            animator.SetBool("follow", follow);
            StartCoroutine(waitDie());
        }
    }*/

    private IEnumerator waitDie()
    {
        Player.deaths += 1;
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    public void dano()
    {
        vida -= 1;
    }

    public void hit()
    {
        hitAnimator = true;

        if (hitAnimator)
        {
            
            //StartCoroutine(waitHitCoroutine());
            //hitAnimator = false;

        }
        animator.SetBool("hitAnimator", hitAnimator);
    }

    private IEnumerator waitHitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        
    }
}
