using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLines : MonoBehaviour
{
    public GameObject player;
    public GameObject wire;
    private Vector3 startingVector = Vector3.zero;
    private bool drop = false;
    private bool hasEntered = false;
    private BoxCollider2D m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasEntered && Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("hello :)))");
            if(drop)
            {
                startingVector = Vector3.zero;
                drop = false;
            } else
            {
                Debug.Log("hiiiii :)))");
                startingVector = player.transform.position - transform.position;
                drop = true;
                hasEntered = false;
            }
        }
        if(hasEntered && drop)
        {
            Debug.Log("wheeeee :)))");
            m_Collider.size = new Vector3(player.transform.position.x - startingVector.x, wire.transform.localScale.y, wire.transform.localScale.z);
            wire.transform.localScale = new Vector3(player.transform.position.x - startingVector.x, wire.transform.localScale.y, wire.transform.localScale.z);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasEntered = true;
        }
    }

}
