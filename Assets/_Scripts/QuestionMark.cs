using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

 
public class QuestionMark : MonoBehaviour
{

    public GameObject tip; 
    

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
        Debug.Log("QuestionMark");
        // Destroy (this.gameObject);
        if (Vector3.Distance(this.transform.position,player.transform.position) < 7.0f) 
            tip.gameObject.SetActive(true);

  } 

}
