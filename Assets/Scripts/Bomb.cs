using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float countdown = 2f;
    [SerializeField] MapDestroyer mapDestroyer;

    public void Start()
    {
        mapDestroyer = FindObjectOfType<MapDestroyer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f)
        {
            Debug.Log("Boom!!");
            mapDestroyer.Explode(this.transform.position);
            Destroy(gameObject); 
        }
        
    }
}
