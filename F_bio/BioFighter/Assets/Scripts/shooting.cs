using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
   public Transform firepoint;
    LineRenderer laser;

    private void Start()
    {
        laser = gameObject.GetComponent<LineRenderer>();
        laser.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("shoot");
            StartCoroutine("shoot");
        }
        print(Movement.wasShooted);
    }

    public IEnumerator shoot()
    {
        while (Input.GetButton("Fire1"))
        {
            laser.enabled = true;
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit rayHit;
            laser.SetPosition(0,ray.origin);
            if(Physics.Raycast(ray, out rayHit, 100))
            {
                laser.SetPosition(1, rayHit.point);
                if(rayHit.transform.tag == "Enemy")
                {
                    print("zasah nepritele");
                    Movement.wasShooted = true;
                }
               
            }
            else
            {
                laser.enabled = false;
                //laser.SetPosition(1, ray.GetPoint(100));
                Movement.wasShooted = false;
            }


            yield return null;
        }
        laser.enabled = false;
    }
}
