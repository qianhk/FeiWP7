// Guids.cs
// MUST match guids.h
using System;

namespace Njnu.KaiKaiEdit
{
    static class GuidList
    {
        public const string guidKaiKaiEditPkgString = "eed2ab8c-782f-49eb-96e9-810e29633538";
        public const string guidKaiKaiEditCmdSetString = "11e4cec1-2339-4983-8d8e-30e993f854bb";

        public static readonly Guid guidKaiKaiEditCmdSet = new Guid(guidKaiKaiEditCmdSetString);
    };
}