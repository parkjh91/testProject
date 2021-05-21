using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float moveSpeed = 20f;
    float rotateSpeed = 3f;
    Vector3 movement;
    public Image hp;

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveSpeed * z * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * x);

        if(Input.GetKeyDown(KeyCode.Space) && playerRigidbody.velocity.y <= 0)
        {
            playerRigidbody.velocity = Vector3.up * 10;
        }

        MovePoint();

        if(transform.position.y <= -50f)
            SceneManager.LoadScene("GameScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            hp.fillAmount -= 0.2f;

            if (hp.fillAmount <= 0.1f)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }        
    }

    private void MovePoint()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                float y = transform.position.y;

                transform.position = new Vector3(x, y, z);
            }
        }
    }
}
