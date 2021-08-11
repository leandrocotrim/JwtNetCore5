using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.ValueObjects
{
    public class SettingsJWT
    {
        public static readonly byte[] SECRET_HASH = Encoding.ASCII.GetBytes("bafe16e4a26e686ebe272236d797a9f3");
    }
}
