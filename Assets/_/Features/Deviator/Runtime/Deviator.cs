using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deviator.Runtime
{
    public class Deviator : MonoBehaviour
    {


        #region Utils

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision");
            if (collision != null)
            {
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f,ForceMode2D.Impulse);
            }
        }

        #endregion
    }
}
