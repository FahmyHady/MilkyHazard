using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    [SerializeField] KeyCode shootButton;
    [SerializeField] ParticleSystem myShootJet;
    [SerializeField] int shootRate;
    [SerializeField] float maxShootTime;
    [SerializeField] Image fillImage;
    [SerializeField] float coolDownRate;
    float shootTime;
    float shootTimeStamp;
    bool shooting;
    void Update()
    {

        if (Input.GetKey(shootButton) && shootTime < maxShootTime)
        {
            shooting = true;
            myShootJet.Emit(shootRate);
            shootTime += Time.time - shootTimeStamp;
        }
        else if (shootTime > 0 && !shooting)
        {
            shootTime -= Mathf.Clamp(coolDownRate * Time.deltaTime, 0, maxShootTime);
        }
        if (Input.GetKeyUp(shootButton))
        {
            shooting = false;
        }
        shootTimeStamp = Time.time;
        fillImage.fillAmount = shootTime / maxShootTime;
    }
}
