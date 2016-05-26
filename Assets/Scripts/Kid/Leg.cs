using UnityEngine;
using System.Collections;

public class Leg : MonoBehaviour
{
    public Transform top, bottom;
    public Material legMaterial;
    private LineRenderer leg;
    public float bodyOffset;
    public float kneeOffset;

    void Start()
    {
        leg = gameObject.AddComponent<LineRenderer>();
        leg.SetVertexCount(3);
        leg.material = legMaterial;
        leg.SetWidth(.25f, .25f);
    }

    void Update()
    {
        if (leg != null)
        {
            Vector3 topPos = new Vector3(top.position.x + (bodyOffset * transform.parent.localScale.x), top.position.y + .3f, transform.position.z);
            Vector3 midPos = new Vector3(bottom.position.x + (kneeOffset * transform.parent.localScale.x), bottom.position.y + .7f, transform.position.z);
            Vector3 bottomPos = new Vector3(bottom.position.x, bottom.position.y + .1f, transform.position.z);

            leg.SetPosition(0, bottomPos);
            leg.SetPosition(1, midPos);
            leg.SetPosition(2, topPos);
        }
    }
}
