INCLUDE globals.ink
INCLUDE Repair.ink
INCLUDE EndGame.ink
INCLUDE Flower.ink 
INCLUDE All Hallow.ink
INCLUDE MoreScenarios.ink
INCLUDE Plush.ink
->Pick_Knot

=== Pick_Knot ===
//->Hot_Dog|->Test |
{~->Hot_Dog|->Test | ->Flower| ->AllHallow | ->Object | ->Plush}

=== Hot_Dog ===
You found a 100 year old hot dog.
Would you like to eat it?

    + [1. Yes] <> 
        You can't eat. Who do you think you are? -> What
    + [2. No] -> No
    + [3. What] -> What


== No == 
The hotdog gets mad and beats you up.
            ~ health = health - 1
-> END

== What == 
You heard me.
-> END

=== Test === 
Yeet

-> END