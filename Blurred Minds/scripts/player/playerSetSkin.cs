using UnityEngine;
using System.Collections;

public class playerSetSkin : MonoBehaviour
{
    public GameObject female;
    public GameObject femaleShirt;
    public GameObject male;
    public GameObject maleShirt;

    public GameObject femaleWhole;
    public GameObject maleWhole;

    public Texture[] FemTextures = new Texture[3];
    public Texture[] FemClothes = new Texture[3];
    public Texture[] MaleTextures = new Texture[3];
    public Texture[] MaleClothes = new Texture[3];

    // Use this for initialization
    void Start ()
    {

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        PersistentData.GetPlayerStats().GetPlayerGender();
        PersistentData.GetPlayerStats().GetPlayerSkinIndex();
        //Debug.Log(PersistentData.GetPlayerStats().GetPlayerGender().ToString();

        if (PersistentData.GetPlayerStats().GetPlayerGender() == PlayerStats.PlayerGender.MALE)
        {
            maleWhole.SetActive(true);
            femaleWhole.SetActive(false);
            SetTheSkinMale();
        }
        else if(PersistentData.GetPlayerStats().GetPlayerGender() == PlayerStats.PlayerGender.FEMALE)
        {
            femaleWhole.SetActive(true);
            maleWhole.SetActive(false);
            SetTheSkinFemale();


        }


    }

    void SetTheSkinMale()
    {
       // Material mat = male.GetComponentInChildren<Renderer>().material;
        Material mat2 = maleShirt.GetComponent<Renderer>().sharedMaterial;

        Material[] materials = male.GetComponent<Renderer>().materials;
        Material[] materials2 = maleShirt.GetComponent<Renderer>().materials;
         

        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 1)
        {
            materials[0].mainTexture = MaleTextures[0];
            materials2[0].mainTexture = MaleClothes[0];
            materials2[1].mainTexture = MaleTextures[0];
           // mat2.mainTexture = MaleClothes[0];
        }
        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 2)
        {
            materials[0].mainTexture = MaleTextures[1];
            materials2[0].mainTexture = MaleClothes[1];
            materials2[1].mainTexture = MaleTextures[1];
            //mat2.mainTexture = MaleClothes[1];
        }
        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 3)
        {
            materials[0].mainTexture = MaleTextures[2];
            materials2[0].mainTexture = MaleClothes[2];
            materials2[1].mainTexture = MaleTextures[2];
            //mat2.mainTexture = MaleClothes[2];
        }
    }


   void SetTheSkinFemale()
    {

        Material mat = female.GetComponentInChildren<Renderer>().material;
        Material mat2 = femaleShirt.GetComponent<Renderer>().sharedMaterial;

        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 1)
        {
            mat.mainTexture = FemTextures[0];
            mat2.mainTexture = FemClothes[0];
        }
        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 2)
        {
            mat.mainTexture = FemTextures[1];
            mat2.mainTexture = FemClothes[1];
        }
        if (PersistentData.GetPlayerStats().GetPlayerSkinIndex() == 3)
        {
            mat.mainTexture = FemTextures[2];
            mat2.mainTexture = FemClothes[2];
        }
    }

}
