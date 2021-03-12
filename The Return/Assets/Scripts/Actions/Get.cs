using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        for (int i = 0; i < controller.player.currentLocation.items.Count; i++)
        {
            Item item = controller.player.currentLocation.items[i];
            if (item.itemEnabled && item.itemName.ToLower() == noun.ToLower()) 
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun;
                    return;
                }    
            }
        }
        controller.currentText.text = "You can't take that";
    }
}
