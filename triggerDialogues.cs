using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class triggerDialogues : MonoBehaviour
{
    [SerializeField] GameObject dialouges;
    [SerializeField] int howLongToWait;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialouges.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(waitForFinish());
        }
    }
    IEnumerator waitForFinish()
    {
        yield return new WaitForSeconds(howLongToWait);
        dialouges.SetActive(false);
    }

}
