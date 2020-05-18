using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField]
    private float blastSpeed = 1f;
    [SerializeField]
    private GameObject gfxOnDestroy;

    private float scale = 1;

    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(scale, 0) * blastSpeed * Time.deltaTime, Space.World);
    }

    public void SetDirection(float scale)
    {
        this.scale = scale;
        transform.localScale = new Vector3(Mathf.Sign(scale) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnDestroy()
    {
        _trailRenderer.transform.parent = null;
        _trailRenderer.autodestruct = true;
        _trailRenderer = null;
        Instantiate(gfxOnDestroy, transform.position, Quaternion.identity);
    }
}
