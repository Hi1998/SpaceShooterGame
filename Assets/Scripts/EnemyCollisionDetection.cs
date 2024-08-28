using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision enemyCol)
    {
        if(enemyCol.gameObject.tag == "Bullets")
        {
            Destroy(enemyCol.gameObject);
        }
    }
}
