using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("destroyParticle", 1.5f);
    }
    private void destroyParticle()
    {
        Destroy(this.gameObject);
    }
}
