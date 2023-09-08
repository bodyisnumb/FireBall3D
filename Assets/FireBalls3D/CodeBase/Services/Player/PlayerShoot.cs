using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float cooldown = 0.2f;

    private bool _canShoot = true;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_canShoot) return;

        BulletMove bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity).GetComponent<BulletMove>();
        bullet.MoveTo(muzzlePoint, transform.forward);


        StartCoroutine(GunCooldown());
        
    }

    private IEnumerator GunCooldown()
    {
        _canShoot = !_canShoot; //false
        yield return new WaitForSeconds(cooldown);
        _canShoot = !_canShoot; //true
    }

    public void GameOver()
    {
        gameState.OnGameOver?.Invoke();
        enabled = false;
    }
}
