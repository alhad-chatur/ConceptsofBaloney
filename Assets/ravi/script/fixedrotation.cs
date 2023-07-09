using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedrotation : MonoBehaviour
{
    public Transform trans;
    // Start is called before the first frame update
  
    

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(0, 90, 0);
    }
}
