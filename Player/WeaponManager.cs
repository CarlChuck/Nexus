using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    #region Singleton
    public static WeaponManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    //the parent transforms for mesh to instantiate at
    public Transform rightHand;
    public Transform leftHand;

    //The mesh objects in hands
    public GameObject rHandItem;
    public GameObject lHandItem;

    //The weapons from inventory
    public InventoryItem inRightHand;
    public InventoryItem inLeftHand;

    //parent locations for WeaponIcons
    public Transform RHAbilityIconBase;
    public Transform LHAbilityIconBase;

    //The images in UI bottom panel
    public GameObject RHAbilityImage;
    public GameObject LHAbilityImage;

    public Inventory inventory;
    [SerializeField] private PlayerAnimator pAnimator;


    //Updates the mesh and bottom pane icons to match inventory weapons
    public void UpdateWeapons()
    {
        inRightHand = null;
        inLeftHand = null;

        Destroy(rHandItem);
        Destroy(RHAbilityImage);
        RHAbilityImage = null;
  
        Destroy(lHandItem);
        Destroy(LHAbilityImage);
        LHAbilityImage = null;

        if (inventory.rHand != null)
        {
            inRightHand = inventory.rHand;
            RHAbilityImage = Instantiate(inRightHand.icon3d,RHAbilityIconBase);
            if (inRightHand.handedness == Handed.TwoHanded)
            {
                LHAbilityImage = Instantiate(inRightHand.icon3d, LHAbilityIconBase);
            }
            rHandItem = Instantiate(inRightHand.mesh, rightHand);
        }
        if (inventory.lHand != null)
        {
            inLeftHand = inventory.lHand;
            LHAbilityImage = Instantiate(inLeftHand.icon3d, LHAbilityIconBase);
            lHandItem = Instantiate(inLeftHand.mesh, leftHand);
        }
    }

    //functions to use weapon to attack
    public void Attack1()
    {
        if (inRightHand != null)
        {
            WeaponAttack1();            
        }
    }    
    public void Attack2()
    {
        if (inRightHand != null)
        {
            WeaponAttack2();
        }

    }    
    public void Attack3()
    {
        if (inRightHand != null && inLeftHand == null)
        {
            if (inRightHand.handedness == Handed.TwoHanded)
            {
                WeaponAttack3();
            }
        }
        else if (inLeftHand != null)
        {
            if (inRightHand != null)
            {
                WeaponAttack3();
            }
        }
    }    
    public void Attack4()
    {
        if (inRightHand != null && inLeftHand == null)
        {
            if (inRightHand.handedness == Handed.TwoHanded)
            {
                WeaponAttack4();
            }
        }
        else if (inLeftHand != null)
        {
            if (inRightHand != null)
            {
                WeaponAttack4();
            }
        }
    }
    
    public void WeaponAttack1()
    {
        Player player = Player.instance;
        Animator anim = player.anim;
        WeaponType wType = inRightHand.wType;

        //Muzzle Flashes
        if (rHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = rHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }

        if (wType == WeaponType.Melee)
        {
            anim.SetTrigger("MeleeRSwipe");
            Transform emitter = player.centreEmitter;
            Melee1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.HPistol)
        {
            anim.SetTrigger("PistolRShoot");
            Transform emitter = player.rightEmitter;
            HPistol1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.PPistol)
        {
            anim.SetTrigger("PistolRShoot");
            Transform emitter = player.rightEmitter;
            PPistol1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Rifle)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Rifle1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.GravGun)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            GravGun1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Carbine)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Carbine1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Wand)
        {
            anim.SetTrigger("WandRShoot");
            Transform emitter = player.rightEmitter;
            Wand1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Staff)
        {
            anim.SetTrigger("StaffShoot");
            Transform emitter = player.centreEmitter;
            Staff1(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.NanoGlove)
        {
            anim.SetTrigger("NanoRShoot");
            Transform emitter = player.rightEmitter;
            NanoGlove1(player, inRightHand, emitter);
        }
    }
    public void WeaponAttack2()
    {
        Player player = Player.instance;
        Animator anim = player.anim;
        WeaponType wType = inRightHand.wType;

        //Muzzle Flashes
        if (rHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = rHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }

        if (wType == WeaponType.Melee)
        {
            anim.SetTrigger("MeleeRSwipe");
            Transform emitter = player.centreEmitter;
            Melee2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.HPistol)
        {
            anim.SetTrigger("PistolRShoot");
            Transform emitter = player.rightEmitter;
            HPistol2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.PPistol)
        {
            anim.SetTrigger("PistolRShoot");
            Transform emitter = player.rightEmitter;
            PPistol2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Rifle)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Rifle2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.GravGun)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            GravGun2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Carbine)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Carbine2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Wand)
        {
            anim.SetTrigger("WandRShoot");
            Transform emitter = player.rightEmitter;
            Wand2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.Staff)
        {
            anim.SetTrigger("StaffShoot");
            Transform emitter = player.centreEmitter;
            Staff2(player, inRightHand, emitter);
        }
        else if (wType == WeaponType.NanoGlove)
        {
            anim.SetTrigger("NanoRShoot");
            Transform emitter = player.rightEmitter;
            NanoGlove2(player, inRightHand, emitter);
        }
    }    
    public void WeaponAttack3()
    {
        Player player = Player.instance;
        Animator anim = player.anim;
        WeaponType wType = inLeftHand.wType;

        //Muzzle Flashes
        if (lHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = lHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }
        else if (rHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = rHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }

        if (wType == WeaponType.Melee)
        {
            anim.SetTrigger("MeleeLSwipe");
            Transform emitter = player.centreEmitter;
            Melee3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.HPistol)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            HPistol3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.PPistol)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            PPistol3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Shield)
        {
            anim.SetTrigger("ShieldSwing");
            Transform emitter = player.centreEmitter;
            Shield3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Launcher)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            Launcher3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Rifle)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Rifle3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Carbine)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Carbine3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.GravGun)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            GravGun3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Wand)
        {
            anim.SetTrigger("WandLShoot");
            Transform emitter = player.leftEmitter;
            Wand3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Foci)
        {
            anim.SetTrigger("FociCast");
            Transform emitter = player.leftEmitter;
            Foci3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Staff)
        {
            anim.SetTrigger("StaffShoot");
            Transform emitter = player.centreEmitter;
            Staff3(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.NanoGlove)
        {
            anim.SetTrigger("NanoLShoot");
            Transform emitter = player.leftEmitter;
            NanoGlove3(player, inLeftHand, emitter);
        }
    }
    public void WeaponAttack4()
    {
        Player player = Player.instance;
        Animator anim = player.anim;
        WeaponType wType = inLeftHand.wType;

        //Muzzle Flashes
        if (lHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = lHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }
        else if (rHandItem.GetComponent<WeaponModel>())
        {
            WeaponModel wModel = rHandItem.GetComponent<WeaponModel>();
            wModel.WeaponFlash();
        }

        if (wType == WeaponType.Melee)
        {
            anim.SetTrigger("MeleeLSwipe");
            Transform emitter = player.centreEmitter;
            Melee4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.HPistol)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            HPistol4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.PPistol)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            PPistol4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Shield)
        {
            anim.SetTrigger("ShieldSwing");
            Transform emitter = player.centreEmitter;
            Shield4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Launcher)
        {
            anim.SetTrigger("PistolLShoot");
            Transform emitter = player.leftEmitter;
            Launcher4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Rifle)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Rifle4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Carbine)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            Carbine4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.GravGun)
        {
            anim.SetTrigger("RifleShoot");
            Transform emitter = player.centreEmitter;
            GravGun4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Wand)
        {
            anim.SetTrigger("WandLShoot");
            Transform emitter = player.leftEmitter;
            Wand4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Foci)
        {
            anim.SetTrigger("FociCast");
            Transform emitter = player.leftEmitter;
            Foci4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.Staff)
        {
            anim.SetTrigger("StaffShoot");
            Transform emitter = player.centreEmitter;
            Staff4(player, inLeftHand, emitter);
        }
        else if (wType == WeaponType.NanoGlove)
        {
            anim.SetTrigger("NanoLShoot");
            Transform emitter = player.leftEmitter;
            NanoGlove4(player, inLeftHand, emitter);
        }
    }

    public void Melee1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Mystic
            case AttunementType.Mystic:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;
            //Shadow
            case AttunementType.Shadow:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Melee2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Apoch
            case AttunementType.Apoch:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void Melee3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Mystic
            case AttunementType.Mystic:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;
            //Shadow
            case AttunementType.Shadow:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Melee4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Apoch
            case AttunementType.Apoch:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }

    public void Shield3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;

            //Artificer
            case AttunementType.ArtificerRazer:

                break;

            case AttunementType.ArtificerAssault:

                break;

            case AttunementType.ArtificerBattle:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;
        }
    }
    public void Shield4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;

            //Artificer
            case AttunementType.ArtificerRazer:

                break;

            case AttunementType.ArtificerAssault:

                break;

            case AttunementType.ArtificerBattle:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;
        }
    }

    public void HPistol1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.LightningRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.EarthRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.FlameRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.IceRound(player, weap, emitter);
                break;

            //Mystic
            case AttunementType.Mystic:

                break;

            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void HPistol2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.LightningPulse(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.MeteorShot(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.Conflagration(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.FrostSpear(player, weap, emitter);
                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void HPistol3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.AirRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.CrystalRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.MagmaRound(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.WaterRound(player, weap, emitter);
                break;

            //Mystic
            case AttunementType.Mystic:

                break;

            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void HPistol4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.StaticForce(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.GravitonCrystal(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.FlameBlast(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.VapourRound(player, weap, emitter);
                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }

    public void PPistol1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Psyc
            case AttunementType.Psyc:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void PPistol2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Psyc
            case AttunementType.Psyc:
                break;

            //Apoch
            case AttunementType.Apoch:
                break;

            //Crypter
            case AttunementType.Crypter:
                break;

            //Shadow
            case AttunementType.Shadow:
                break;
        }
    }
    public void PPistol3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Psyc
            case AttunementType.Psyc:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void PPistol4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Psyc
            case AttunementType.Psyc:
                break;

            //Apoch
            case AttunementType.Apoch:
                break;

            //Crypter
            case AttunementType.Crypter:
                break;

            //Shadow
            case AttunementType.Shadow:
                break;
        }
    }

    public void Carbine1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Carbine2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Carbine3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Carbine4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }

    public void Rifle1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void Rifle2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void Rifle3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }
    public void Rifle4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Shadow
            case AttunementType.Shadow:

                break;
        }
    }

    public void Launcher3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void Launcher4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Envoy
            case AttunementType.Envoy:

                break;

            //Vigil
            case AttunementType.Vigil:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }

    public void Wand1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.LightningBolt(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.CrystalSwarm(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.FireBolts(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.WaterBolt(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Wand2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.ChainLightning(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.CrystalWave(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.PyroclasticSurge(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.WaterBlast(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;
        }
    }
    public void Wand3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.AirBurst(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.RockLance(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.FireBall(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.GlacialSpike(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Wand4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.Cyclone(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.Earthquake(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.Firestorm(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.Permafrost(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;
        }
    }

    public void Staff1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Staff2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Staff3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Staff4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }

    public void Foci3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.GustOfWind(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.MagneticPulse(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.RingOfFire(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.CleansingFog(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }
    public void Foci4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Golemancer
            case AttunementType.GolemancerStone:

                break;
            case AttunementType.GolemancerCrystal:

                break;
            case AttunementType.GolemancerSteel:

                break;
            case AttunementType.GolemancerArcane:

                break;

            //Elementalist
            case AttunementType.ElementalistAir:
                abilities.ShockingAura(player, weap, emitter);
                break;
            case AttunementType.ElementalistEarth:
                abilities.GraniteAura(player, weap, emitter);
                break;
            case AttunementType.ElementalistFire:
                abilities.FlamingAura(player, weap, emitter);
                break;
            case AttunementType.ElementalistWater:
                abilities.MistAura(player, weap, emitter);
                break;

            //Psyc
            case AttunementType.Psyc:

                break;

            //Mystic
            case AttunementType.Mystic:

                break;
        }
    }

    public void NanoGlove1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }
    public void NanoGlove2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }
    public void NanoGlove3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }
    public void NanoGlove4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;

            //Street Doc
            case AttunementType.StreetDoc:

                break;
        }
    }

    public void GravGun1(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }
    public void GravGun2(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }
    public void GravGun3(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }
    public void GravGun4(Player player, InventoryItem weap, Transform emitter)
    {
        Abilities abilities = Abilities.instance;
        switch (player.classMechanic.eAttunement)
        {
            //Artificer
            case AttunementType.ArtificerRazer:

                break;
            case AttunementType.ArtificerAssault:

                break;
            case AttunementType.ArtificerBattle:

                break;

            //Apoch
            case AttunementType.Apoch:

                break;

            //Crypter
            case AttunementType.Crypter:

                break;

            //Nano Mage
            case AttunementType.NanoMage:

                break;
        }
    }

}
public enum AttunementType
{
    //Golemancer
    GolemancerStone, GolemancerCrystal, GolemancerSteel, GolemancerArcane,
    //Elementalist
    ElementalistAir, ElementalistEarth, ElementalistFire, ElementalistWater,
    //Psyc
    Psyc,
    //Mystic
    Mystic,
    //Artificer
    ArtificerRazer, ArtificerAssault, ArtificerBattle,
    //Apoch
    Apoch,
    //Crypter
    Crypter,
    //Nano-Mage
    NanoMage,
    //Envoy
    Envoy,
    //Vigil
    Vigil,
    //Shadow
    Shadow,
    //Street-Doc
    StreetDoc
}

