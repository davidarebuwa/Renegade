using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHit = 10;
    [SerializeField] int enemyHealthPoints = 25;

    [SerializeField] int hits = 5;

    ScoreBoard scoreBoard;




    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        
    }


    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);

        hits--;

        if (hits <= 1) {
            KillEnemy();
        }

        KillEnemy();

    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //show explosion before enemy is destroyed
        fx.transform.parent = parent;
        print("Bullets done damage  to " + gameObject.name);
        Destroy(gameObject);
    }
}
