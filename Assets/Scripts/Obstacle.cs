using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float dropSpeed = 20f;
    private ParticleSystem particle;
    Vector3 startPos;
    Quaternion startRot;
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        particle = GameObject.Find("BigExplosion").GetComponent<ParticleSystem>();
        SetStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * dropSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        particle.transform.position = new Vector3(transform.position.x, transform.position.y + 0.226f, transform.position.z + 1.435f);
        particle.Play();
        Destroy(gameObject);
    }

    private void SetStartPosition()
    {
        x = Random.Range(-25.0f, 25.0f);
        y = 30;
        z = Random.Range(-25.0f, 25.0f);

        startPos = new Vector3(x, y, z);
        transform.position = startPos;

        x = 90;
        y = 0;
        z = Random.Range(0, 360);

        startRot.eulerAngles = new Vector3(x, y, z);
        transform.rotation = startRot;
    }
}
