using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UMA;
//using UMA.CharacterSystem;
using UnityEngine.UI;
using System.IO;

public class UMACreator : MonoBehaviour
{
    /*
    public Transform bodyLevel;
    public Transform faceLevel;
    public Transform theCamera;

    public DynamicCharacterAvatar avatar;
    private Dictionary<string, DnaSetter> dna;
    public Slider heightSlider;
    public Slider bellySlider;
    public Slider waistSlider;
    public Slider armLength;
    public Slider armWidth;
    public Slider breastCleavage;
    public Slider breastSize;
    public Slider cheekPosition;
    public Slider cheekSize;
    public Slider chinPosition;
    public Slider chinPronounce;
    public Slider chinSize;
    public Slider earsPosition;
    public Slider earsRotation;
    public Slider earsSize;
    public Slider eyeRotation;
    public Slider eyeSize;
    public Slider eyeSpacing;
    public Slider feetSize;
    public Slider forearmLength;
    public Slider forearmWidth;
    public Slider foreHeadSize;
    public Slider foreHeadPosition;
    public Slider gluteusSize;
    public Slider handsSize;
    public Slider headSize;
    public Slider headWidth;
    public Slider jawsPosition;
    public Slider jawsSize;
    public Slider legsSize;
    public Slider legsSeparation;
    public Slider lipsSize;
    public Slider lowCheekPositions;
    public Slider lowCheekPronounced;
    public Slider lowerMuscle;
    public Slider lowerWeight;
    public Slider mandibleSize;
    public Slider mouthSize;
    public Slider neckThickness;
    public Slider noseCurve;
    public Slider noseFlatten;
    public Slider noseIncline;
    public Slider nosePosition;
    public Slider nosePronounce;
    public Slider noseSize;
    public Slider noseWidth;
    public Slider upperMuscle;
    public Slider upperWeight;
    public string myRecipe;

    private void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
        heightSlider.onValueChanged.AddListener(HeightChange);
        bellySlider.onValueChanged.AddListener(BellyChange);
        waistSlider.onValueChanged.AddListener(WaistChange);
        armLength.onValueChanged.AddListener(ArmLengthChange);
        armWidth.onValueChanged.AddListener(ArmWidthChange);
        breastCleavage.onValueChanged.AddListener(BreastCleavageChange);
        breastSize.onValueChanged.AddListener(BreastSizeChange);
        cheekPosition.onValueChanged.AddListener(CheekPositionChange);
        cheekSize.onValueChanged.AddListener(CheekSizeChange);
        chinPosition.onValueChanged.AddListener(ChinPositionChange);
        chinPronounce.onValueChanged.AddListener(ChinPronounceChange);
        chinSize.onValueChanged.AddListener(ChinSizeChange);
        earsPosition.onValueChanged.AddListener(EarsPositionChange);
        earsRotation.onValueChanged.AddListener(EarsRotationChange);
        earsSize.onValueChanged.AddListener(EarsSizeChange);
        eyeRotation.onValueChanged.AddListener(EyeRotationChange);
        eyeSize.onValueChanged.AddListener(EyeSizeChange);
        eyeSpacing.onValueChanged.AddListener(EyeSpacingChange);
        feetSize.onValueChanged.AddListener(FeetSizeChange);
        forearmLength.onValueChanged.AddListener(ForearmLengthChange);
        forearmWidth.onValueChanged.AddListener(ForearmWidthChange);
        foreHeadSize.onValueChanged.AddListener(ForeHeadSizeChange);
        foreHeadPosition.onValueChanged.AddListener(ForeHeadPositionChange);
        gluteusSize.onValueChanged.AddListener(GluteusSizeChange);
        handsSize.onValueChanged.AddListener(HandSizeChange);
        headSize.onValueChanged.AddListener(HeadSizeChange);
        headWidth.onValueChanged.AddListener(HeadWidthChange);
        jawsPosition.onValueChanged.AddListener(JawsPositionChange);
        jawsSize.onValueChanged.AddListener(JawSizeChange);
        legsSize.onValueChanged.AddListener(LegSizeChange);
        legsSeparation.onValueChanged.AddListener(LegSeparationChange);
        lipsSize.onValueChanged.AddListener(LipSizeChange);
        lowCheekPositions.onValueChanged.AddListener(LowCheeksPositionChange);
        lowCheekPronounced.onValueChanged.AddListener(LowCheekPronouncedChange);
        lowerMuscle.onValueChanged.AddListener(LowerMuscleChange);
        lowerWeight.onValueChanged.AddListener(LowerWeightChange);
        mandibleSize.onValueChanged.AddListener(MandibleSizeChange);
        mouthSize.onValueChanged.AddListener(MouthSizeChange);
        neckThickness.onValueChanged.AddListener(NeckThicknessChange);
        noseCurve.onValueChanged.AddListener(NoseCurveChange);
        noseFlatten.onValueChanged.AddListener(NoseFlattenChange);
        noseIncline.onValueChanged.AddListener(NoseInclineChange);
        nosePosition.onValueChanged.AddListener(NosePositionChange);
        nosePronounce.onValueChanged.AddListener(NosePronounceChange);
        noseSize.onValueChanged.AddListener(NoseSizeChange);
        noseWidth.onValueChanged.AddListener(NoseWidthChange);
        upperMuscle.onValueChanged.AddListener(UpperMuscleChange);
        upperWeight.onValueChanged.AddListener(UpperWeightChange);
}

    private void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
        heightSlider.onValueChanged.RemoveListener(HeightChange);
        bellySlider.onValueChanged.RemoveListener(BellyChange);
        waistSlider.onValueChanged.RemoveListener(WaistChange);
        armLength.onValueChanged.RemoveListener(ArmLengthChange);
        armWidth.onValueChanged.RemoveListener(ArmWidthChange);
        breastCleavage.onValueChanged.RemoveListener(BreastCleavageChange);
        breastSize.onValueChanged.RemoveListener(BreastSizeChange);
        cheekPosition.onValueChanged.RemoveListener(CheekPositionChange);
        cheekSize.onValueChanged.RemoveListener(CheekSizeChange);
        chinPosition.onValueChanged.RemoveListener(ChinPositionChange);
        chinPronounce.onValueChanged.RemoveListener(ChinPronounceChange);
        chinSize.onValueChanged.RemoveListener(ChinSizeChange);
        earsPosition.onValueChanged.RemoveListener(EarsPositionChange);
        earsRotation.onValueChanged.RemoveListener(EarsRotationChange);
        earsSize.onValueChanged.RemoveListener(EarsSizeChange);
        eyeRotation.onValueChanged.RemoveListener(EyeRotationChange);
        eyeSize.onValueChanged.RemoveListener(EyeSizeChange);
        eyeSpacing.onValueChanged.RemoveListener(EyeSpacingChange);
        feetSize.onValueChanged.RemoveListener(FeetSizeChange);
        forearmLength.onValueChanged.RemoveListener(ForearmLengthChange);
        forearmWidth.onValueChanged.RemoveListener(ForearmWidthChange);
        foreHeadSize.onValueChanged.RemoveListener(ForearmWidthChange);
        foreHeadPosition.onValueChanged.RemoveListener(ForearmWidthChange);
        gluteusSize.onValueChanged.RemoveListener(GluteusSizeChange);
        handsSize.onValueChanged.RemoveListener(HandSizeChange);
        headSize.onValueChanged.RemoveListener(HeadSizeChange);
        headWidth.onValueChanged.RemoveListener(HeadWidthChange);
        jawsPosition.onValueChanged.RemoveListener(JawsPositionChange);
        jawsSize.onValueChanged.RemoveListener(JawSizeChange);
        legsSize.onValueChanged.RemoveListener(LegSizeChange);
        legsSeparation.onValueChanged.RemoveListener(LegSeparationChange);
        lipsSize.onValueChanged.RemoveListener(LipSizeChange);
        lowCheekPositions.onValueChanged.RemoveListener(LowCheeksPositionChange);
        lowCheekPronounced.onValueChanged.RemoveListener(LowCheekPronouncedChange);
        lowerMuscle.onValueChanged.RemoveListener(LowerMuscleChange);
        lowerWeight.onValueChanged.RemoveListener(LowerWeightChange);
        mandibleSize.onValueChanged.RemoveListener(MandibleSizeChange);
        mouthSize.onValueChanged.RemoveListener(MouthSizeChange);
        neckThickness.onValueChanged.RemoveListener(NeckThicknessChange);
        noseCurve.onValueChanged.RemoveListener(NoseCurveChange);
        noseFlatten.onValueChanged.RemoveListener(NoseFlattenChange);
        noseIncline.onValueChanged.RemoveListener(NoseInclineChange);
        nosePosition.onValueChanged.RemoveListener(NosePositionChange);
        nosePronounce.onValueChanged.RemoveListener(NosePronounceChange);
        noseSize.onValueChanged.RemoveListener(NoseSizeChange);
        noseWidth.onValueChanged.RemoveListener(NoseWidthChange);
        upperMuscle.onValueChanged.RemoveListener(UpperMuscleChange);
        upperWeight.onValueChanged.RemoveListener(UpperWeightChange);
    }

    public void SwitchGender(bool male)
    {
        if (male)
        {
            avatar.ChangeRace("NexusFemaleRace");
        }
        else
        {
            avatar.ChangeRace("NexusMaleRace");
        }
    }

    private void Updated(UMAData data)
    {
        dna = avatar.GetDNA();
        heightSlider.value = dna["height"].Get();
        bellySlider.value = dna["belly"].Get();
        waistSlider.value = dna["waist"].Get();
        armLength.value = dna["armLength"].Get();
        armWidth.value = dna["armWidth"].Get();
        breastCleavage.value = dna["breastCleavage"].Get();
        breastSize.value = dna["breastSize"].Get();
        cheekPosition.value = dna["cheekPosition"].Get();
        cheekSize.value = dna["cheekSize"].Get();
        chinPosition.value = dna["chinPosition"].Get();
        chinPronounce.value = dna["chinPronounced"].Get();
        chinSize.value = dna["chinSize"].Get();
        earsPosition.value = dna["earsPosition"].Get();
        earsRotation.value = dna["earsRotation"].Get();
        earsSize.value = dna["earsSize"].Get();
        eyeRotation.value = dna["eyeRotation"].Get();
        eyeSize.value = dna["eyeSize"].Get();
        eyeSpacing.value = dna["eyeSpacing"].Get();
        feetSize.value = dna["feetSize"].Get();
        forearmLength.value = dna["forearmLength"].Get();
        forearmWidth.value = dna["forearmWidth"].Get();
        foreHeadPosition.value = dna["foreheadPosition"].Get();
        foreHeadSize.value = dna["foreheadSize"].Get();
        gluteusSize.value = dna["gluteusSize"].Get();
        handsSize.value = dna["handsSize"].Get();
        headSize.value = dna["headSize"].Get();
        headWidth.value = dna["headWidth"].Get();
        jawsPosition.value = dna["jawsPosition"].Get();
        jawsSize.value = dna["jawsSize"].Get();
        legsSize.value = dna["legsSize"].Get();
        legsSeparation.value = dna["legSeparation"].Get();
        lipsSize.value = dna["lipsSize"].Get();
        lowCheekPositions.value = dna["lowCheekPosition"].Get();
        lowCheekPronounced.value = dna["lowCheekPronounced"].Get();
        lowerMuscle.value = dna["lowerMuscle"].Get();
        lowerWeight.value = dna["lowerWeight"].Get();
        mandibleSize.value = dna["mandibleSize"].Get();
        mouthSize.value = dna["mouthSize"].Get();
        neckThickness.value = dna["neckThickness"].Get();
        noseCurve.value = dna["noseCurve"].Get();
        noseFlatten.value = dna["noseFlatten"].Get();
        noseIncline.value = dna["noseInclination"].Get();
        nosePosition.value = dna["nosePosition"].Get();
        nosePronounce.value = dna["nosePronounced"].Get();
        noseSize.value = dna["noseSize"].Get();
        noseWidth.value = dna["noseWidth"].Get();
        upperMuscle.value = dna["upperMuscle"].Get();
        upperWeight.value = dna["upperWeight"].Get();
    }

    public void ChangeSkinColour(Color col)
    {
        avatar.SetColor("Skin", col);
        avatar.UpdateColors(true);
    }

    public void HeightChange(float val)
    {
        dna["height"].Set(val);
        avatar.BuildCharacter();
    }
    public void BellyChange(float val)
    {
        dna["belly"].Set(val);
        avatar.BuildCharacter();
    }
    public void WaistChange(float val)
    {
        dna["waist"].Set(val);
        avatar.BuildCharacter();
    }
    public void ForeHeadSizeChange(float val)
    {
        dna["foreheadSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void ForeHeadPositionChange(float val)
    {
        dna["foreheadPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void ArmLengthChange(float val)
    {
        dna["armLength"].Set(val);
        avatar.BuildCharacter();
    }
    public void ArmWidthChange(float val)
    {
        dna["armWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void BreastCleavageChange(float val)
    {
        dna["breastCleavage"].Set(val);
        avatar.BuildCharacter();
    }
    public void BreastSizeChange(float val)
    {
        dna["breastSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void CheekPositionChange(float val)
    {
        dna["cheekPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void CheekSizeChange(float val)
    {
        dna["cheekSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void ChinPositionChange(float val)
    {
        dna["chinPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void ChinPronounceChange(float val)
    {
        dna["chinPronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void ChinSizeChange(float val)
    {
        dna["chinSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void EarsPositionChange(float val)
    {
        dna["earsPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void EarsRotationChange(float val)
    {
        dna["earsRotation"].Set(val);
        avatar.BuildCharacter();
    }
    public void EarsSizeChange(float val)
    {
        dna["earsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void EyeRotationChange(float val)
    {
        dna["eyeRotation"].Set(val);
        avatar.BuildCharacter();
    }
    public void EyeSizeChange(float val)
    {
        dna["eyeSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void EyeSpacingChange(float val)
    {
        dna["eyeSpacing"].Set(val);
        avatar.BuildCharacter();
    }
    public void FeetSizeChange(float val)
    {
        dna["feetSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void ForearmLengthChange(float val)
    {
        dna["forearmLength"].Set(val);
        avatar.BuildCharacter();
    }
    public void ForearmWidthChange(float val)
    {
        dna["forearmWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void GluteusSizeChange(float val)
    {
        dna["gluteusSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void HandSizeChange(float val)
    {
        dna["handsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void HeadSizeChange(float val)
    {
        dna["headSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void HeadWidthChange(float val)
    {
        dna["headWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void JawsPositionChange(float val)
    {
        dna["jawsPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void JawSizeChange(float val)
    {
        dna["jawsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void LegSizeChange(float val)
    {
        dna["legsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void LegSeparationChange(float val)
    {
        dna["legSeparation"].Set(val);
        avatar.BuildCharacter();
    }
    public void LipSizeChange(float val)
    {
        dna["lipsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void LowCheeksPositionChange(float val)
    {
        dna["lowCheekPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void LowCheekPronouncedChange(float val)
    {
        dna["lowCheekPronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void LowerMuscleChange(float val)
    {
        dna["lowerMuscle"].Set(val);
        avatar.BuildCharacter();
    }
    public void LowerWeightChange(float val)
    {
        dna["lowerWeight"].Set(val);
        avatar.BuildCharacter();
    }
    public void MandibleSizeChange(float val)
    {
        dna["mandibleSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void MouthSizeChange(float val)
    {
        dna["mouthSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void NeckThicknessChange(float val)
    {
        dna["neckThickness"].Set(val);
        avatar.BuildCharacter();
    }
    public void NoseCurveChange(float val)
    {
        dna["noseCurve"].Set(val);
        avatar.BuildCharacter();
    }
    public void NoseFlattenChange(float val)
    {
        dna["noseFlatten"].Set(val);
        avatar.BuildCharacter();
    }
    public void NoseInclineChange(float val)
    {
        dna["noseInclination"].Set(val);
        avatar.BuildCharacter();
    }
    public void NosePositionChange(float val)
    {
        dna["nosePosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void NosePronounceChange(float val)
    {
        dna["nosePronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void NoseSizeChange(float val)
    {
        dna["noseSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void NoseWidthChange(float val)
    {
        dna["noseWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void UpperMuscleChange(float val)
    {
        dna["upperMuscle"].Set(val);
        avatar.BuildCharacter();
    }
    public void UpperWeightChange(float val)
    {
        dna["upperWeight"].Set(val);
        avatar.BuildCharacter();
    }

    public void BodyCamera()
    {
        theCamera.position = new Vector3(theCamera.position.x, bodyLevel.position.y, theCamera.position.z);
    }
    public void FaceCamera()
    {
        theCamera.position = new Vector3(theCamera.position.x, faceLevel.position.y, theCamera.position.z);
    }

    public void SaveRecipe()
    {
        myRecipe = avatar.GetCurrentRecipe();
        File.WriteAllText(Application.persistentDataPath + "/dude.txt", myRecipe);
    }

    public void LoadRecipe()
    {
        myRecipe = File.ReadAllText(Application.persistentDataPath + "/dude.txt");
        avatar.ClearSlots();
        avatar.LoadFromRecipeString(myRecipe);
    }
    */
}
