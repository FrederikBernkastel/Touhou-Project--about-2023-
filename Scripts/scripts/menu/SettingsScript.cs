using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsScript
{
    public static int Health = 1;
    public static int Bombs = 1;
    public static GraphicType Graphic;
    public static MusicType Music;
    public static SoundType Sound;
    public static ModeType Mode;

    public enum GraphicType
    {
        b32,
        b16,
    }
    public enum MusicType
    {
        Off,
        WAW,
        MIDI,
    }
    public enum SoundType
    {
        Off,
        On,
    }
    public enum ModeType
    {
        Fullscreen,
        Window,
    }
}
public static class VaribleCharacterScript
{
    public static HardType Hard;
    public static CharacterType Character;
    public static SpellcardType Spellcard;

    public enum HardType
    {
        Izi = 1,
        Normal = 2,
        Hard = 3,
        Lunatic = 4,
    }
    public enum CharacterType
    {
        Marisa = 1,
        Reymu = 2,
    }
    public enum SpellcardType
    {
        type1 = 1,
        type2 = 2,
        type3 = 3,
        type4 = 4,
    }
}
public static class SettingsInputScript
{
    public static KeyCode Up = KeyCode.UpArrow;
    public static KeyCode Down = KeyCode.DownArrow;
    public static KeyCode Left = KeyCode.LeftArrow;
    public static KeyCode Right = KeyCode.RightArrow;
    public static KeyCode Slow = KeyCode.LeftShift;
    public static KeyCode Bomb = KeyCode.X;
    public static KeyCode Damage = KeyCode.Z;
}
