using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform[] path;
    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    private void Start()
    {
        string[] message = { "hello", "everyone", "I", "am" , "radil"};//will print message with 0.5sec gap.
        StartCoroutine(printMessage(message, .5f));
        StartCoroutine(followPath());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentCoroutine != null)//will execute coroutine after the ending of one.
            {
                StopCoroutine(currentCoroutine);
            }
                
            currentCoroutine = move(Random.onUnitSphere * 5, 8);
            StartCoroutine(currentCoroutine); //pick a random point and moves to it
        }
    }


    //creates coroutine to follow some waypoints in a path.
    IEnumerator followPath()
    {
        //will use the move function to follow a series of blocks.
        foreach (Transform waypoint in path)
        {
           yield return StartCoroutine(move(waypoint.position, 8));
        }
            
    }

    //creates coroutine to move block.
    IEnumerator move(Vector3 destination, float speed)
    {
        while (transform.position != destination) //will keep moving item until it reaches a destination.
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    //creates coroutine to print string.
    IEnumerator printMessage(string[] message, float delay)
    {
        //will print 1 message for every letter in the message.
        foreach (string msg in message)
        {
            print(msg);
            yield return new WaitForSeconds(delay);
        }
    }
}
