using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuBossPathing : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 0.1f;

    public GameObject crops;
    public Vector2 centre;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;
    }
}
