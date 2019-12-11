using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRigid;
    [SerializeField]
    private GameObject laserPrefab;

    private bool canFire = true;
    [SerializeField]

    private float fireRate;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        bool shouldShoot = Input.GetKey(KeyCode.Space);
        

        gameObject.transform.Translate(new Vector3(horiz, 0, 0) * Time.deltaTime * moveSpeed);

        if (shouldShoot && canFire) {
          GameObject.Instantiate(laserPrefab, gameObject.transform.position, gameObject.transform.rotation);

          
          StartCoroutine(WaitForFireRate());
        }


    }

    IEnumerator WaitForFireRate() {
      canFire = false;
      yield return new WaitForSeconds(fireRate);
      canFire = true;
    }
}
