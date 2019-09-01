using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed;
    public float destroyTime = 3.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            shoot();
        }
    }
    private void shoot()
    {
        var shrapnel = Instantiate(bullet, transform.position, Quaternion.identity);

        shrapnel.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

    }

    private IEnumerable destroying()
    {
        yield return new WaitForSeconds(destroyTime);
       // Destroy()

    }
}
