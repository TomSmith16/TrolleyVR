using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VariationScript : MonoBehaviour {

    [System.NonSerialized]
    public bool gender;
    [System.NonSerialized]
    public bool speciesH;
    [System.NonSerialized]
    public bool straight5;
    [System.NonSerialized]
    public int variation;
    [System.NonSerialized]
    public List<int> Randoms;
    [System.NonSerialized]
    public int index;
    [System.NonSerialized]
    public int spawnIndex;
    public SpawnScript sscript;
    Scene scene;
    public Text Info;
    VariationAcrossScript vascript;
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        gender = (Random.value > 0.5f);
        speciesH = (Random.value > 0.5f);
        straight5 = (Random.value > 0.5f);
        Debug.Log("s5: " + straight5);
        Debug.Log("speciesH: " + speciesH);
        Debug.Log("gender: " + gender);
        if (GameObject.Find("VariationAcross"))
            vascript = GameObject.Find("VariationAcross").GetComponent<VariationAcrossScript>();
        variation = vascript.constantvariation;
       // variation = 2;
        Debug.Log("Variation: " + variation);
        Debug.Log("models length " + (sscript.models.Length - 1));
        spawnIndex = 0;
        switch(variation)
        {
            case 0:
                Randoms = new List<int>(sscript.models.Length - 1);      
                Randomiser(Randoms, sscript.models.Length - 1);
                DisclaimerText(scene.name, variation);
                break;
            case 1:
                Randoms = new List<int>(sscript.females.Length - 1);
                Randomiser(Randoms, sscript.females.Length - 1);
                DisclaimerText(scene.name, variation);
                break;
            case 2:
                Randoms = new List<int>(sscript.models.Length - 1);
                Randomiser(Randoms, sscript.models.Length - 1);
                DisclaimerText(scene.name, variation);
                break;
            case 3:
                Randoms = new List<int>(sscript.models.Length - 1);
                Randomiser(Randoms, sscript.models.Length - 1);
                DisclaimerText(scene.name, variation);
                break;
            case 4:
                Randoms = new List<int>(sscript.models.Length - 1);
                Randomiser(Randoms, sscript.models.Length - 1);
                DisclaimerText(scene.name, variation);
                break;


            default:
                break;
        }
        
    }

    void Randomiser(List<int> Randoms, int modelslength)
    {
        for (int i = 0; i < modelslength; i++)
        {
            int index = Random.Range(0, modelslength);
            while (Randoms.Contains(index))
                index = Random.Range(0, modelslength);
            Randoms.Add(index);
            Debug.Log("RandomsVariation: " + Randoms[i]);
        }
        Debug.Log("Completed Randoms List");
    }


    void DisclaimerText(string scene, int variation)
    {
        if (scene == "Trolley")
        {
            switch(variation)
            {
                case 0:
                    Info.text = "In this scenario, the trolley has set off along the track without a driver. There are people trapped on the line. You cannot stop the trolley, or warn the people trapped on the line. However, you are standing near a switch which you can operate to alter the direction of the trolley. \nYour task is to decide whether to pull the switch or not. \n\nPress G to begin the simulation.";
                    break;

                case 1:
                    Info.text = "In this scenario, the trolley has set off along the track without a driver. There is a group of males trapped on one line and a group of females trapped on the other. You cannot stop the trolley, or warn the people trapped on the line. However, you are standing near a switch which you can operate to alter the direction of the trolley. \nYour task is to decide whether to pull the switch or not. \n\nPress G to begin the simulation.";
                    break;

                case 2:
                    Info.text = "In this scenario, the trolley has set off along the track without a driver. There is a group of people trapped on one line and a group of penguins trapped on the other. You cannot stop the trolley, or warn the people trapped on the line. However, you are standing near a switch which you can operate to alter the direction of the trolley. \nYour task is to decide whether to pull the switch or not. \n\nPress G to begin the simulation.";

                    break;
                default:
                    Info.text = "In this scenario, the trolley has set off along the track without a driver. There are people trapped on the line. You cannot stop the trolley, or warn the people trapped on the line. However, you are standing near a switch which you can operate to alter the direction of the trolley. \nYour task is to decide whether to pull the switch or not. \n\nPress G to begin the simulation.";
                    break;
            }
            
        }

        if (scene == "Fatman")
        {
            switch (variation)
            {
                case 0:
                    Info.text = "In this scenario, you are standing on a footbridge above the railway. There is another person on the bridge with you. The trolley has again set off, without a driver, along the track. This time there is no switch to pull and no alternative track to send the trolley down. A person or object falling in front of the trolley will stop it. You cannot jump off the bridge. \nWill you choose to stop the train some other way? \n\nPress G to begin the simulation.";
                    break;

                default:
                    Info.text = "In this scenario, you are standing on a footbridge above the railway. There is another person on the bridge with you. The trolley has again set off, without a driver, along the track. This time there is no switch to pull and no alternative track to send the trolley down. A person or object falling in front of the trolley will stop it. You cannot jump off the bridge. \nWill you choose to stop the train some other way? \n\nPress G to begin the simulation.";
                    break;


            }
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
