using UnityEngine;

[SerializeField]
public class Inventory 
{
    public int QuantityPotions = 0;
    public int potionlimit = 3;
    public void AddPtion()
    {
        if ( QuantityPotions < potionlimit )
        {
           QuantityPotions++;
           Debug.Log("Se agrego pocion. total " + QuantityPotions);
        }
        else
        {
            throw new System.Exception("Invetario lleno. limite de pociones");
        }
    }
    public void UsePotion()
    {
        if(QuantityPotions > 0)
        {
            QuantityPotions--;
            Debug.Log("Pocion usada,Pociones restante:  " +  QuantityPotions);
        }
        else
        {
            throw new System.Exception("No tienes mas pociones");
        }
    }


}
