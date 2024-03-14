using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    [SerializeField] int liveToAdd;

    private void Update()
    {
        FallDown();
    }

    void FallDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);
    }

    public void ApplyPowerUp()
    {
        GameManager.i.UpdateNumberOfLives(liveToAdd);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }
}
