using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float delay;
    float timer;
    public bool canInstant;

    // Update is called once per frame
    void Update()
    {
        if (canInstant)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                canInstant = false;
            }
        }
        else if (!canInstant)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0;
                canInstant = true;
            }
        }

    }

    IEnumerator MakeIdle()
    {
        canInstant = false;
        yield return new WaitForSeconds(delay);
        canInstant = true;
    }
}
