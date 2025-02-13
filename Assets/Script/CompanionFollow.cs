using UnityEngine;

public class CompanionFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float followDistance;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Companion"), LayerMask.NameToLayer("Player"));
    }

    void Update()
    {
     float distance = Vector3.Distance(transform.position, player.position);
     if (distance > followDistance)
     {
        Vector3 targetPosition = player.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
     }   
    }
}
