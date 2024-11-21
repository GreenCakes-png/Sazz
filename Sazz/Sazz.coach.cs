using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

using System;
using System.ComponentModel;
using System.Numerics;

namespace Neo.SmartContract.Template
{
    public partial class Sazz : Nep17Token
    {
        private const byte Prefix_Coach = 0xab;

        [Safe]
        public static UInt160 GetCoach() => (UInt160)Storage.Get(new[] { Prefix_Coach });

        public static void SetCoach(UInt160 manager)
        {
            if (IsOwner() == false)
                throw new InvalidOperationException("No Authorization!");

            Storage.Put(new[] { Prefix_Coach }, manager);
        }
    }
}
