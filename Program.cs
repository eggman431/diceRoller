main();

void main() {
    string[] weapons = new string[] { "shortsword", "longsword", "mace" };
    Console.WriteLine();
    Console.WriteLine("Roll the dice! Enter a number 4 to 20 to roll the dice.");
    Console.WriteLine("You may also enter one of the following weapons: ");
    foreach (string weapon in weapons) {
        Console.Write(weapon + " ");
    }

    Console.WriteLine("Type exit to leave.");
    var input = Console.ReadLine();
    if (input != null) {
        input = input.ToLower();
        try {
            if (input.Equals("exit")) {
                Environment.Exit(0);
            } else if (input.Any(x => !char.IsLetter(x))) {
                getDice(Int32.Parse(input));
            } else if (weapons.Contains(input)) {
                weaponUsed(input);
            } else {
                throw new Exception();
            }
        } catch {
            Console.WriteLine("Error, wrong input.");
        } finally {
            main();
        }
    }
}

void weaponUsed(string input) {
    switch (input) {
        case "shortsword":
            getDiceWithModifier(6, 2);
            break;
        case "longsword":
            getDiceWithModifier(8, 2);
            break;
        case "mace":
            getDiceWithModifier(6, 1);
            break;
    }
}

void getDiceWithModifier(int dice, int modifier) {
    Random r = new Random();
    var result = r.Next(1+modifier, dice+1+modifier);
    Console.WriteLine("The result of your roll was: " + result);
}

void getDice(int dice) {
    if (dice >= 4 && dice <= 20) {
        Console.WriteLine("You roll a " + dice + " sided dice");
        Random result = new Random();
        Console.WriteLine("The result of your roll was: " + result.Next(1, dice + 1));
    } else {
        throw new Exception();
    }
}