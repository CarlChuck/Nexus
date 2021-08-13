using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	//Declare player object, and offset variable for the camera position.
    public GameObject player;
	[SerializeField] private Vector3 offset;

    Transform target;
    float pendingShakeDuration = 0f;
    float shakeVariance = 1f;
    bool isShaking = false;

    void Start ()
    {
        player = Player.instance.gameObject;
        target = GetComponent<Transform>();
        //Centres camera above player.
        //offset = transform.position - player.transform.position;
        DontDestroyOnLoad(this);
	}

	void LateUpdate ()
    {
        if (!isShaking)
        {
            //Camera follows player.
            transform.position = player.transform.position + offset;
        }
	}

    private void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    public void shake(float duration, float variance)
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
            shakeVariance = variance;
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(offset.x + Random.Range(-shakeVariance, shakeVariance), offset.y + Random.Range(-shakeVariance, shakeVariance), 
                offset.z + Random.Range(-shakeVariance, shakeVariance));
            transform.position = player.transform.position + randomPoint;
            yield return null;
        }
        pendingShakeDuration = 0;
        isShaking = false;
    }
}
