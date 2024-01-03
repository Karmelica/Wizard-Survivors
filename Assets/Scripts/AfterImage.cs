using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    void SpawnTrail()
    {
        GameObject trailPart = new("AfterImage");
        SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
        trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        trailPart.transform.SetPositionAndRotation(transform.position, transform.rotation);
        Destroy(trailPart, 0.5f);

        StartCoroutine(nameof(FadeTrailPart), trailPartRenderer);
    }
    IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
    {
        Color color = trailPartRenderer.color;
        color.a -= 0.55f;
        trailPartRenderer.color = color;

        yield return new WaitForEndOfFrame();
    }

    public void StartAfterimage()
    {
        InvokeRepeating(nameof(SpawnTrail), 0, 0.1f);
    }

    public void StopAfterimage()
    {
        StopAllCoroutines();
        CancelInvoke();
    }
}
