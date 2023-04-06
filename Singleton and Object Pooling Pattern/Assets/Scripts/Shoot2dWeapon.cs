/*
 * (Jacob Welch)
 * (Shoot2dWeapon)
 * (Singleton and Object Pooling Pattern)
 * (Description: A weapon that shoots 2d bullets.)
 */
using UnityEngine;

public class Shoot2dWeapon : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The time this weapon was last fired.
    /// </summary>
    private float timeOfLastShot = -Mathf.Infinity;

    [Range(0.0f, 10.0f)]
    [Tooltip("The time between bullets being fired")]
    [SerializeField] private float timeBetweenShots = 0.1f;

    [Tooltip("The pool for this weapons bullets")]
    [SerializeField] private Pool bulletObjectPool;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Start()
    {
        ObjectPooler.InitializeNewPool(bulletObjectPool);
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && timeOfLastShot + timeBetweenShots < Time.time)
        {
            ShootWeapon();
        }
    }

    /// <summary>
    /// Shoots the weapon by calling for the object pool to spawn a new weapon.
    /// </summary>
    private void ShootWeapon()
    {
        timeOfLastShot = Time.time;
        var bulletInstance = ObjectPooler.SpawnFromPool(bulletObjectPool.Prefab.name, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<BulletMovement>().Initialize(bulletObjectPool.Prefab.name);
    }
    #endregion
}
