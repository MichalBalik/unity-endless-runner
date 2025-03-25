using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public GameObject prefabBonus;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //menu = GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= 20)
        {
            generujBonus();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            generujBonus();

        }

    }
    public void generujBonus()
    {
        Vector3 player = rb.transform.position;
        Vector3 direction = rb.transform.forward;
        
        Vector3 spawn = player + direction * 30;
        GameObject bonus = Instantiate(prefabBonus, spawn, Quaternion.identity);



        bonus.tag = "RandomEffect";
        bonus.AddComponent<RotateCoin>();
        bonus.AddComponent<selfD>();
        bonus.AddComponent<BoxCollider>();
        Debug.Log("GENERUJEM BONUS");
    }
}
