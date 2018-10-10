using UnityEngine;
using System.Collections;

public enum characterGender {none, female, male };


public class CharacterCustomisatoin : MonoBehaviour {

    //Enumerators 
    public characterGender charGender;

    //booleans
    bool windowActive = true;

    //integers
    public Texture[] FemTextures = new Texture[3];
    public Texture[] FemClothes = new Texture[3];
    public Texture[] MaleTextures = new Texture[3];
    public Texture[] MaleClothes = new Texture[3];
    public static int tex = 1;

    //Gameobjects and Materials
    public GameObject Femaleplayer;
    public GameObject MalePlayer;
    public GameObject femShirt;
    public GameObject maleShirt;

  
    public void ChangeGenderFemale(bool gender)
    {
        if(gender==true)
        {
            charGender = characterGender.female;
        }

    }

    public void ChangeGenderMale(bool gender)
    {
        if(gender ==true)
        {
            charGender = characterGender.male;
        }
    }

    //public void ChangeSkinUp(int tex)
    //{
    //    if (CharacterCustomisatoin.tex < 3)
    //    {
    //        CharacterCustomisatoin.tex++;
    //        Debug.Log("Skin number =" + CharacterCustomisatoin.tex.ToString());
    //    }
    //    else if (CharacterCustomisatoin.tex >= 3)
    //    {
    //        CharacterCustomisatoin.tex = 1;
    //        Debug.Log("Skin number =" + CharacterCustomisatoin.tex.ToString());
    //    }
    //}

    //public void ChangeSkinDown(int tex)
    //{
    //    if (CharacterCustomisatoin.tex >= 1)
    //    {
    //        CharacterCustomisatoin.tex--;
    //        Debug.Log("Skin number =" + CharacterCustomisatoin.tex.ToString());
    //    }
    //    else if (CharacterCustomisatoin.tex <= 1)
    //    {
    //        CharacterCustomisatoin.tex = 3;
    //    }

    //}

    // Use this for initialization
    void Start ()
    {
       // characterState charState;
        charGender = characterGender.none;

      
     

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(windowActive == true)
        {
            if(charGender==characterGender.female)
            {
                //playerAppearanceFemale();
                Femaleplayer.SetActive(true);
                MalePlayer.SetActive(false);
                //tex = FemTextures.Length;
            }
            else if(charGender==characterGender.male)
            {
                //playerAppearanceMale();
                MalePlayer.SetActive(true);
                Femaleplayer.SetActive(false);
               // tex = MaleTextures.Length;
            }
        }


        PersistentData.GetPlayerStats().SetPlayerSkinIndex(tex);

    }

    //void playerAppearanceMale()
    //{
    //    Material mat = MalePlayer.GetComponentInChildren<Renderer>().material;
    //    Material mat2 = maleShirt.GetComponent<Renderer>().sharedMaterial;
    //    if(tex<=1)
    //    {
    //        mat.mainTexture = MaleTextures[0];
    //        mat2.mainTexture = MaleClothes[0];
    //    }
    //    if(tex>=2)
    //    {
    //        mat.mainTexture = MaleTextures[1];
    //        mat2.mainTexture = MaleClothes[1];
    //    }
    //    if(tex>=3)
    //    {
    //        mat.mainTexture = MaleTextures[2];
    //        mat2.mainTexture = MaleClothes[2];
    //    }     
    //}
  

    //void playerAppearanceFemale()
    //{
       
    //    Material mat = Femaleplayer.GetComponentInChildren<Renderer>().material;
    //    Material mat2 = femShirt.GetComponent<Renderer>().sharedMaterial;
    //    if (tex<=1)
    //    {
    //        mat.mainTexture = FemTextures[0];
    //        mat2.mainTexture = FemClothes[0];
    //    }
    //    if (tex>= 2)
    //    {
    //        mat.mainTexture = FemTextures[1];
    //        mat2.mainTexture = FemClothes[1];
    //    }
    //    if (tex>=3)
    //    {
    //        mat.mainTexture = FemTextures[2];
    //        mat2.mainTexture = FemClothes[2];
    //    }
    //}
}
