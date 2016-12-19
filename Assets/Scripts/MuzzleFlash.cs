using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

    void OnEnable()
    {
        StartCoroutine("Disappear");
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
