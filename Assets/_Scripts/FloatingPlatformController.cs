using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformController : MonoBehaviour
{
    
    public bool isActive;
    

    public PlayerBehaviour player;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        
        isActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _Shrink();
        }
        
    }

    private void _Shrink()
    {
        StartCoroutine(ScaleOverTime(2));
    }

    public void Reset()
    {
        gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 orginalScale = gameObject.transform.localScale;
        Vector3 finalScale = new Vector3(0.0f, 0.0f, 0.0f);

        float curTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(orginalScale, finalScale, curTime / time);
            curTime += Time.deltaTime;
            yield return null;

        } while (curTime <= time);
    }
}
