using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class goalArea : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            //Debug.Log("Goal was scored");
            StartCoroutine(resetBall(collision));
        }
        
    }

    private IEnumerator resetBall(Collider2D puck)
    {
        puck.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        puck.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        for (int i=3;i>0;i--)
        {
            //display index here as text
            yield return new WaitForSeconds(1f);
        }
        puck.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        puck.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
