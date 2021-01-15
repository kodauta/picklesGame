using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration;
    public float magnitude;
    public void Shake(GameObject mainCamera)
    {
        StartCoroutine( DoShake(mainCamera, duration, magnitude ) );
    }

    private IEnumerator DoShake(GameObject mainCamera, float duration, float magnitude )
    {
        var pos = mainCamera.transform.localPosition;

        var elapsed = 0f;

        while ( elapsed < duration )
        {
            var x = pos.x + Random.Range( -1f, 1f ) * magnitude;
            var y = pos.y + Random.Range( -1f, 1f ) * magnitude;

            mainCamera.transform.localPosition = new Vector3( x, y, pos.z );

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = pos;
    }
}

