using System.Linq;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private Animator _lightningAnim;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _damage = 1f;
    private RandomPosGenerator _posGenerator;
    private bool _isAttackFinished = false;

    // Start is called before the first frame update
    private void Start()
    {
        _lightningAnim = GetComponent<Animator>();
        transform.position = _posGenerator.Generate();
        var boundary = GeneralConstants.mapBoundaries;
        _posGenerator = new RandomPosGenerator(boundary, 2, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0f)
        {
            _lightningAnim.SetTrigger("Strike");
            if (!_isAttackFinished)
                Attack();
            Destroy(gameObject, 0.5f);
        }
    }

    private void Attack()
    {
        var colliderSize = GetComponent<Collider2D>().bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, colliderSize, 0f);
        foreach (var collider in colliders)
        {
            var obj = collider.gameObject;
            if (obj.CompareTag("Player"))
            {
                Player player = obj.GetComponent<Player>();
                player.GetDamage(_damage);
            }
            else if (obj.CompareTag("Enemy"))
            {
                IEnemy enemy = obj.GetComponents<MonoBehaviour>().OfType<IEnemy>().FirstOrDefault();
                enemy.GetDamage(_damage);
            }
        }
        _isAttackFinished = true;
    }
}