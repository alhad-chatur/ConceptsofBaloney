using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnememy : MonoBehaviour
{

    public GameObject theenemy;
    public int enemycount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());

    }
    IEnumerator EnemyDrop()
    {
        while (enemycount < 520)
        {
            
            Instantiate(theenemy, new Vector3(97.9f, -0.7f, 0.5f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemycount++;
        }
    }
}
