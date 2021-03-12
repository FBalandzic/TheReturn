using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //use items in room
        if (useItem(controller, controller.player.currentLocation.items, noun))
            return;

        //use item in inventory
        if (useItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool useItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.CanUseItem(controller, item))
                {
                    if (item.InteractWith(controller, "use"))
                    {
                        return true;
                    }
                }
                controller.currentText.text = "The " + noun + " does nothing";

                return true;
            }
        }
        return false;
    }
}
