using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageVariblesScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        string name = _transform.name;

        if (name == "легко" || name == "норма" || name == "сложно" || name == "лунатик")
        {
            if (name == "легко")
                VaribleCharacterScript.Hard = VaribleCharacterScript.HardType.Izi;
            else if (name == "норма")
                VaribleCharacterScript.Hard = VaribleCharacterScript.HardType.Normal;
            else if (name == "сложно")
                VaribleCharacterScript.Hard = VaribleCharacterScript.HardType.Hard;
            else if (name == "лунатик")
                VaribleCharacterScript.Hard = VaribleCharacterScript.HardType.Lunatic;
        }
        else if (name == "рейму" || name == "мариса")
        {
            if (name == "рейму")
                VaribleCharacterScript.Character = VaribleCharacterScript.CharacterType.Reymu;
            else if (name == "мариса")
                VaribleCharacterScript.Character = VaribleCharacterScript.CharacterType.Marisa;
        }
        else if (
            name == "атака духа" || name == "атака мечты" || 
            name == "атака магии" || name == "атака любви")
        {
            if (name == "атака духа")
                VaribleCharacterScript.Spellcard = VaribleCharacterScript.SpellcardType.type1;
            else if (name == "атака мечты")
                VaribleCharacterScript.Spellcard = VaribleCharacterScript.SpellcardType.type2;
            else if (name == "атака магии")
                VaribleCharacterScript.Spellcard = VaribleCharacterScript.SpellcardType.type3;
            else if (name == "атака любви")
                VaribleCharacterScript.Spellcard = VaribleCharacterScript.SpellcardType.type4;
        }
    }
}
