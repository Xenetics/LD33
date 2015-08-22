using UnityEngine;
using System.Collections;

public class WaterLerper : MonoBehaviour
{
    [SerializeField]
    private Material water1;
    [SerializeField]
    private Material water2;
    [SerializeField]
    private float duration;
    private Renderer rend;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material = water1;
    }
	
	void Update ()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        water2.color = new Color(water2.color.r, water2.color.g, water2.color.b, lerp);
	}
}
