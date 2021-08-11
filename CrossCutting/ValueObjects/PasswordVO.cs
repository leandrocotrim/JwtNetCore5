using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.ValueObjects
{
    public class PasswordVO
    {
        public static readonly string SMALL_LETTERS = "abcdefghijklmnopqrstuvwxyz";

        public static readonly string CAPITAL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static readonly string NUMBERS = "0123456789";

        public static readonly string SPECIAL_CHARACTERS = "@#_-&!";
    }
}
