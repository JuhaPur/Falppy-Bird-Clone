using UnityEngine;
<<<<<<< HEAD

// testo

=======
//->
>>>>>>> 67e8539d0fb1837dc24b43cc21d3097ca9db050f
public class CameraShake : MonoBehaviour
{
    public Camera cam;

    float shakeAmount = 0;

    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.005f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if(shakeAmount > 0)
        {
            Vector2 camPos = cam.transform.position;
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            cam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        cam.transform.localPosition = Vector2.zero;
    }
}
