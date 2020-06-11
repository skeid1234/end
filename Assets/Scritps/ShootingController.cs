using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public LayerMask layerMask;
    public bool IsBulletMode = true;
    public float Force = 100;
    public GameObject Bullet;
    public Transform BulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!IsBulletMode)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(ray, out hit, layerMask))
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            else
            {
                var temp = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
                temp.GetComponent<Rigidbody>().AddForce(BulletSpawnPoint.forward.normalized * Force);
            }
        }
    }
}
