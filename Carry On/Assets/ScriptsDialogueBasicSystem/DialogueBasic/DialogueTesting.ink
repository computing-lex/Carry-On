-> main

=== main ===
You found a 100 year old hot dog.
Would you like to eat it?
    + [Yes]
        ->chosen("Yes")
    + [No]
        ->chosen("No")    
    + [I can eat?]
        ->chosen("ICE")

=== chosen(choice) ===
Choice: {choice}

-> END
