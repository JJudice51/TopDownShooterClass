using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIBehavior : MonoBehaviour
{
    [SerializeField]
    private RawImage _healthBarFG;

    [SerializeField]
    private HealthBehaviour _healthBehavior;

    [SerializeField]
    private Gradient _healthBarGradient;

    private float _maxHealth;

    private void Start()
    {
        Debug.Assert(_healthBarFG);
        Debug.Assert(_healthBehavior);

   

    }

    private void Update()
    {
        //Ensure components are valid. This is a guard class
        if (_healthBarFG == null || _healthBehavior == null)
            return;

        // Get Health
        float health = _healthBehavior.Health;

        //Minimum of 1 to ensure no dividing by zero or negative numbers. dividing by zero will cause fatal crash in pretty much all codebases.
        float maxHealth = Mathf.Max(1, _healthBehavior.MaxHealth);
        
      

        //get health as value b/t 0 and 1
        float healthPercentage = Mathf.Clamp01(health / maxHealth);

        //set health bar scale
        Vector3 newScale = _healthBarFG.rectTransform.localScale;
        newScale.x = healthPercentage;
        _healthBarFG.rectTransform.localScale = newScale;

        //
        _healthBarFG.color = _healthBarGradient.Evaluate(healthPercentage);


    }










}
