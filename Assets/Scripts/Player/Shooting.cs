using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Pooling pool;
    [SerializeField] private float cadenceTime;
    [SerializeField] private SpriteRenderer sprite;

    private float timer = 0f;
    private bool canShoot = true;

    private void Update()
    {
        if(!canShoot)
            Timer();
        if (Input.GetKey(KeyCode.K) && canShoot)
            Shoot();
    }

    private void Shoot()
    {
        canShoot = false;
        GameObject clone = pool.Obtain();
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
        clone.GetComponent<IBulletDirecion>().BulletDirection(sprite.flipX);
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= cadenceTime)
        {
            timer = 0f;
            canShoot = true;
        }
    }
}
