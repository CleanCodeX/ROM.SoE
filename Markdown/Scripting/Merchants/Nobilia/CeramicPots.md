# Ceramic pots merchant

```csharp
/// <summary>
/// Most relevant code for talking to Ceramic Pot merchant
/// </summary>
public void CeramicPotMerchant()
{
	const byte flagCeramicPotMerchant = 0x10;

	if ((_228b_TalkedToPersons & flagCeramicPotMerchant) > 0)
		Dialog("Would you like some ceramic pots? They're only 2 bags of rice each.");
	else
	{
		Dialog("What you need, my friend, is ceramic pots. They're a classic design, very durable and priced to move only 2 bags of rice per pot.");
		_228b_TalkedToPersons |= flagCeramicPotMerchant;
	}

	var v289f_WannaBuyPots = SelectionDialog("What do you say?", "I'm sold!", "I'll pass.");
	UInt32 v285b_PotsToBuy = 0; // initial set to zero
	UInt16 v289d_HowManyPots;

	if (v289f_WannaBuyPots != 0)
	{
		v289d_HowManyPots = SelectionDialog("How many?", "One.", "Five.", "Ten.");

		if (v289d_HowManyPots == 0)
			v285b_PotsToBuy = 1;  // (1 pot)
		else if (v289d_HowManyPots == 1)
			v285b_PotsToBuy = 5; // (5 pots)
		else if (v289d_HowManyPots == 2)
			v285b_PotsToBuy = 10; // (10 pots)
		else
			CancelDialog();
	}

	if (v285b_PotsToBuy != 0)
	{
		if (_2527_OwnedRice < v285b_PotsToBuy * 2)
		{
			_243d_UnknownStatusMaybe = 0;
			Dialog(" Can't buy (not enough rice)");
		}
		else if (_251b_OwnedPots + v285b_PotsToBuy > 0x63) // Max 99 items check
		{
			_243d_UnknownStatusMaybe = 2;
			Dialog("Can't buy (inventory full)");
		}
		else
		{
			PlaySound(0x40);
			Dialog("It's a deal. Thank you very much.");

			_2527_OwnedRice = (UInt16)(_2527_OwnedRice - v285b_PotsToBuy * 2);
			_251b_OwnedPots = (UInt16)(_251b_OwnedPots + v285b_PotsToBuy);

			goto BuySuccess;
		}
	}

	CancelDialog();

	return;

BuySuccess:

	Debug.Print("UNTRACED INSTR for script caller (0x08)");

	// Subroutine
	void CancelDialog()
	{
		var arg0 = Random.Next(0, 16);
		if (arg0 == 4)
			Dialog("Kids... Always looking, never buying.");
		else if (arg0 == 8)
			Dialog("How can you pass up my deals?");
		else if (arg0 == 7)
			Dialog("Yeesh... Tourists!");
		else if (arg0 > 12)
			Dialog("Fine... Have a nice day!");
		else
			Dialog("OK. Maybe some other time.");

		arg0 = Random.Next(0, 8);

		if (arg0 == 5)
			Dialog("Now please make room for paying customers.");
	}

	if (_251b_OwnedPots > _285d_Unknown + 6) // more than 6 (not 5 [!]) pots buyed (option 10 pots)
		// Reusage of dialog response variable!
		v289d_HowManyPots = (UInt16)Random.Next(0, 16); // 1/16 chance (0-15)
	else if (_251b_OwnedPots > _285d_Unknown + 1) // more than 1 pot buyed (option 5 pots)
		// Reusage of dialog response variable!
		v289d_HowManyPots = (UInt16)Random.Next(0, 8); // 1/8 chance (0-7)
	else
		// Reusage of dialog response variable!
		v289d_HowManyPots = 15; // Means there is never a chance to find something

	if (v289d_HowManyPots < 3) // (0,1,2) means 3/16 or 3/8 chance of finding something
	{
		Debug.Print("Stop/disable boy (and SELECT button)");
		Debug.Print("MAKE boy FACE SOUTH");
		Debug.Print("YIELD (break out of script loop, continue later)"); // Probably necessary for calling global script 0x09
		Debug.Print("CALL Unnamed Global script 0x09"); // What's that?

		Dialog("Hey! One of these ceramic pots has something in it!");

		const UInt16 flagMagicGourd = 0x4;
		const UInt16 flagChocoboEgg = 0x40;

		if ((_2262_Charms & flagMagicGourd) == 0)
		{
			if ((_2262_Charms & flagChocoboEgg) == 0)
			{
				var tmp = Random.Next(0, 16); // 1/16 chance
				if (tmp == 7)
				{
					_243d_UnknownStatusMaybe = 2;
					Dialog("Found the Chocobo Egg.");
				}
				else
				{
					_Jewels += 10;
					Dialog("Found 10 Jewels.");
				}
			}
			else // *) 2 branches with same content
			{
				_Jewels += 50;
				Dialog("Found 50 Jewels.");
			}
		}
		else // *) 2 branches with same content
		{
			_Jewels += 50;
			Dialog("Found 50 Jewels.");
		}
	}

	Debug.Print("BOY = Player controlled");
}
```

