/*
 * (Jacob Welch)
 * (BulletMovement)
 * (Singleton and Object Pooling Pattern)
 * (Description: Handles the movement for bullets.)
 */
using UnityEngine;


public class BulletMovement : MonoBehaviour
{
    #region Fields
    [Tooltip("How fast the bullet will move forward")]
    [SerializeField] private float speed = 1;

    [Tooltip("The max distance that the bullet can travel")]
    [SerializeField] private float maxTravelDistance = 5;

    /// <summary>
    /// The position that the bullet is spawned at.
    /// </summary>
    private Vector2 startPosition;

    /// <summary>
    /// The name of the prefab that this object was spawned from.
    /// </summary>
    private string prefabName;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    public void Initialize(string prefabName)
    {
        this.prefabName = prefabName;
        startPosition = transform.position;
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        MoveBullet();
        CheckTravelDistance();
    }

    /// <summary>
    /// Moves the bullet forward.
    /// </summary>
    private void MoveBullet()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    /// <summary>
    /// Checks the distance the bullet has traveled and destroys it if it has traveled past its max distance.
    /// </summary>
    private void CheckTravelDistance()
    {
        if(maxTravelDistance < Vector3.Distance(transform.position, startPosition))
        {
            ObjectPooler.ReturnObjectToPool(prefabName, gameObject);
        }
    }
    #endregion
}
