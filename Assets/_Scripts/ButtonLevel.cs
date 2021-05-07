using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{

    public Loader.Scene scene ;
    public GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){

        if (Vector3.Distance(this.transform.position,player.transform.position) < 7) 
          Loader.Load(scene);
  } 
}
 