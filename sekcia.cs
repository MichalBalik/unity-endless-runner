using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sekcia : MonoBehaviour
{
    
    public List<GameObject> sekcie;
    
    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            
            int nahodnyIndex = Random.Range(0, sekcie.Count);
            Debug.Log(nahodnyIndex +"/"+ sekcie.Count);
           
            GameObject nahodnaSekcia = sekcie[nahodnyIndex];
            Vector3 poloha = Vector3.zero;
            poloha.z = transform.parent.position.z + 200f;
            Instantiate(nahodnaSekcia, poloha, Quaternion.identity);

            Destroy(transform.parent.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
