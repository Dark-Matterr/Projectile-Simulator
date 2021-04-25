using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text angle, height, distance, textsliderSpeed, gravity, mass;
    public Slider sliderSpeed, sliderHeight, sliderGravity, SliderMass;
    public GameObject wholeCannon, cannonturretObj, cylinderObj, targetObj, cannonstandObj;
    private Cannon cannon;
    private float originalCannonPos, originalCylinderPos;
    // Start is called before the first frame update
    void Start()
    {
        cannon = cannonturretObj.GetComponent<Cannon>();
        originalCannonPos = wholeCannon.transform.position.y;
        originalCylinderPos = cylinderObj.transform.localScale.y;
    }

        // Update is called once per frame
        void Update()
    {
        SetUp();
        textsliderSpeed.text = cannon.initialSpeed.ToString() + " m/s";
        angle.text = Mathf.Round(cannon.initialAngle).ToString() + "\u00BA";
        height.text = sliderHeight.value.ToString() + " m";

        gravity.text = sliderGravity.value.ToString("F") + "m/s\xB2";
        mass.text = SliderMass.value.ToString("F")+" kg";
    }

    void SetUp()
    {
        cannon.initialSpeed = Convert.ToInt32(sliderSpeed.value);
        cannon.initialHeight = Convert.ToInt32(sliderHeight.value);
        cannon.initialGravity = Convert.ToInt32(sliderGravity.value);
        wholeCannon.transform.position = new Vector3(0.75f, originalCannonPos + Convert.ToInt32(sliderHeight.value), -1375.745f);
        cylinderObj.transform.localScale = new Vector3(0.7593249f, originalCylinderPos * Convert.ToInt32(sliderHeight.value), 1f);

    }

    
}
