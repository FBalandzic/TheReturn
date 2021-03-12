using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check items in room
        if (checkItems(controller, controller.player.currentLocation.items, noun))
            return;

        //check item in inventory
        if (checkItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "You can't see a " + noun;
    }

    private bool checkItems(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName.ToLower() == noun.ToLower() && item.itemEnabled)
            {
                if (item.InteractWith(controller,"examine") )
                {
                    if(item.itemName.ToLower() == "well")
                    {
                        return true;
                    }
                    return true;
                }

                controller.currentText.text = "You see " + item.description;

                return true;
            }
        }
        return false;
    }
}
