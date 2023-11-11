using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject pickupText;
    private GameObject text;
    public GameObject player;
    private bool hasEntered = false;
    private bool isMoving = false;
    private Vector3 startingVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasEntered && Input.GetKeyDown(KeyCode.F))
        {
            if(text && !isMoving)
            {
                text.GetComponent<TextMesh>().text = "press \"f\" to drop";
                isMoving = true;
                startingVector = player.transform.position - transform.position;
            } else if(text && isMoving)
            {
                text.GetComponent<TextMesh>().text = "press \"f\" to pick up, \"0\" or \"1\" to link";
                Vector3 temp = new(-1.5f, -0.8f, 0);
                text.transform.position = gameObject.transform.position + temp;
                isMoving = false;
                startingVector = Vector3.zero;
            }
            //gameObject.transform.position += player.transform.position;
        }

        if(isMoving && startingVector != Vector3.zero)
        {
            //gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
            gameObject.transform.position = player.transform.position - startingVector;
            Vector3 temp = transform.position - text.transform.position + new Vector3(-0.8f, -0.8f, 0);
            text.transform.position += temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text = Instantiate(pickupText, transform.position, Quaternion.identity);
            Vector3 temp = new(-1.5f, -0.8f, 0);
            text.transform.position += temp;
            hasEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(text)
        {
            Destroy(text);
        }
        hasEntered = false;
        isMoving = false;
    }
}
