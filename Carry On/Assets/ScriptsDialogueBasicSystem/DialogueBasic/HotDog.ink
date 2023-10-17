=== Hot_Dog ===
You found a 100 year old hot dog.
Would you like to eat it?

    + [1. Yes] <> 
        You can't eat. Who do you think you are? 
            ->END
    + [2. No] -> No
    + [3. What] -> What


== No == 
The hotdog gets mad and beats you up.
            ~ health = health - 1
-> END

== What == 
You consider the existence of such an ancient hot dog. What a strange thing to find.
-> END