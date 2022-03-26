using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class IngredientMerge : MonoBehaviour
{
    [SerializeField] private GameObject bread;
    [SerializeField] private Transform breadBack;
    
    private const float TwoSidedMergeBlockerDistanceConstant = 0.07f; //Sıkıntı çıkarabilir, şu anda tam sınırda. (Salatalık)

    private const float MinMergeAngle = 55f;
    private const float MaxMergeAngle = 125f;

    private float _zAngleBread;
    
    private bool _merged;
    
    [SerializeField] private Recipe recipe;

    [SerializeField] private GameObject successParticle;
    [SerializeField] private GameObject failParticle;
    private void OnTriggerStay(Collider col)
    {
        if (!_merged && SandwichMerge.CurrentSlotValue < SandwichMerge.MaxSlotValue)
        {
            _zAngleBread = col.transform.rotation.eulerAngles.z;

            if (SandwichMerge.CurrentSlotValue == 0)
            {
                if ( (_zAngleBread % 180 > MinMergeAngle  && _zAngleBread % 180 < MaxMergeAngle ) || (_zAngleBread % 180 < -MinMergeAngle  && _zAngleBread % 180 > -MaxMergeAngle ) )
                {

                    MergeIngredientWithSandwich(gameObject, bread);
                
                    ////CompareIngredientMergedAndRecipe(recipe.sandwichLayers[SandwichMerge.CurrentSlotValue].ToString(),bread.transform.GetChild(SandwichMerge.CurrentSlotValue).GetChild(0).tag, recipe.sandwichLayers[SandwichMerge.CurrentSlotValue + 1].ToString());

                    transform.Rotate(0, Random.Range(0, 360), 0);
                    
                    //////col.transform.SetPositionAndRotation(col.transform.position, Quaternion.AngleAxis());

                    //Malzeme ekmeğe yapışırken puf diye duman efekti konacak.
                    
                    
                    SandwichMerge.CurrentSlotValue++;
                    _merged = true;

                    if (transform.position.x - breadBack.position.x < TwoSidedMergeBlockerDistanceConstant) //Eger ilk sandviç ters alınırsa:
                    {
                        col.transform.Rotate(0,0,180); //Ekmeği 180 derece döndür ki anlaşılmasın.
                    }
                }
            }

            else
            {
                if ( transform.position.x - breadBack.position.x > TwoSidedMergeBlockerDistanceConstant && (_zAngleBread % 180 > MinMergeAngle  && _zAngleBread % 180 < MaxMergeAngle ) || (_zAngleBread % 180 < -MinMergeAngle  && _zAngleBread % 180 > -MaxMergeAngle ) )
                {

                    
                    MergeIngredientWithSandwich(gameObject, bread);
                
                    ////CompareIngredientMergedAndRecipe(recipe.sandwichLayers[SandwichMerge.CurrentSlotValue].ToString(), bread.transform.GetChild(SandwichMerge.CurrentSlotValue).GetChild(0).tag, recipe.sandwichLayers[SandwichMerge.CurrentSlotValue + 1].ToString());

                    transform.Rotate(0, Random.Range(0, 360), 0);
                    
                    //////col.transform.SetPositionAndRotation(col.transform.position, Quaternion.AngleAxis());
            
                    //Malzeme ekmeğe yapışırken puf diye duman efekti konacak.
                    bread.transform.GetChild(SandwichMerge.CurrentSlotValue - 1).GetChild(0)
                            .GetComponent<BoxCollider>().enabled = false; //Turns the trigger collider off of previous ingredient collected.

                    SandwichMerge.CurrentSlotValue++;
                    _merged = true;
                }
            }
            
            
            
        }
    }

    private void OnCollisionEnter()
    {
        if (!_merged)
        {
            DestroyIngredient(gameObject);
        }
    }

    private void MergeIngredientWithSandwich(GameObject ingredient, GameObject sandwich)
    {
        ingredient.transform.SetParent(sandwich.transform.GetChild(SandwichMerge.CurrentSlotValue)
            .transform);
        ingredient.transform.SetPositionAndRotation(sandwich.transform.GetChild(SandwichMerge.CurrentSlotValue)
            .transform.position, sandwich.transform.GetChild(SandwichMerge.CurrentSlotValue)
            .transform.rotation);

        Instantiate(successParticle, ingredient.transform.position, Quaternion.identity);
    }

    private void DestroyIngredient(GameObject obj)
    {
        Instantiate(failParticle, obj.transform.position, Quaternion.identity);
        
        Destroy(obj);
        
        //Puf particle oynayacak.
    }

    /*
    private void CompareIngredientMergedAndRecipe(string currentIngredient, string collectedIngredient, string nextIngredient)
    {
        if (currentIngredient == collectedIngredient)
        {
            Debug.Log("Doğru Malzeme!");
            //Güncelle ve sipariş kağıdında öncekine tik at.
        }
        else
        {
            Debug.Log("Yanlış Malzeme!");
            //Güncelle ama sipariş kağıdında öncekine çarpı at.
        }

        if (gameObject.CompareTag(nextIngredient))
        {
            Debug.Log("Tik açılıyor.");
        }
        else
        {
            Debug.Log("Çarpı açılıyor.");
        }
    }
    */
    
}
