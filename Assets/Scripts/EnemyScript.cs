using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerManager;
    public bool chasePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chasePlayer)
        {
            this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }

    public void TPToSpawn()
    {
        this.gameObject.transform.position = enemySpawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            UIManager.Instance.UpdatePlayerHealth(-1);
        }
    }
}
