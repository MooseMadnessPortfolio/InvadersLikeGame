using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpawnScript))]
public class CannonScript : MonoBehaviour
{
    public float xMax;
    public float xMin;

    private Animator animControll;
    private bool canFire = true;
    private int fireTriggerHash;
    private SpriteRenderer sRender;
    private Sprite normalSprite;
    private AudioSource audioSource;
    private SpawnScript bulletSpawnScript;

    private void Start()
    {
        animControll = GetComponent<Animator>();
        fireTriggerHash = Animator.StringToHash("Fire");
        sRender = GetComponent<SpriteRenderer>();
        normalSprite = sRender.sprite;
        audioSource = GetComponent<AudioSource>();
        bulletSpawnScript = GetComponent<SpawnScript>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(xMax, transform.position.y, 0), 0.5f);
        Gizmos.DrawWireSphere(new Vector3(xMin, transform.position.y, 0), 0.5f);
    }   

    public void Fire()
    {
        if (canFire)
        {
            canFire = false;
            bulletSpawnScript.Spawn();
            animControll.SetTrigger(fireTriggerHash);
            if (audioSource.enabled)
                audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public void SetPosition(float x)
    {
        Vector2 newPos = transform.position;
        newPos.x = Mathf.Clamp(x, xMin, xMax);
        transform.position = newPos;
    }

    public void OnEndFireAnim()
    {
        canFire = true;
        sRender.sprite = normalSprite;
    }
}