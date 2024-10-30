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
        // TODO: Replace "EXAMPLE" with a short name all UPPERCASE 3-8 characters
        public override string Symbol { [Safe] get => "FANTASY"; }

        // NOTE: Valid Range 0-31
        public override byte Decimals { [Safe] get => 8; }

        public static new void Burn(UInt160 account, BigInteger amount)
        {
            if (IsOwner() == false)
                throw new InvalidOperationException("No Authorization!");
            Nep17Token.Burn(account, amount);
        }

        public static new void Mint(UInt160 to, BigInteger amount)
        {
            if (IsOwner() == false)
                throw new InvalidOperationException("No Authorization!");
            Nep17Token.Mint(to, amount);
        }

        public new static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
        {
            if(!from.Equals(GetCoach()) || !to.Equals(GetCoach()))
                throw new Exception("Token can only be used to play with!");
            if (from is null || !from.IsValid)
                throw new Exception("The argument \"from\" is invalid.");
            if (to is null || !to.IsValid)
                throw new Exception("The argument \"to\" is invalid.");
            if (amount < 0)
                throw new Exception("The amount must be a positive number.");
            //if (!Runtime.CheckWitness(from)) return false;
            if (amount != 0)
            {
                if (!UpdateBalance(from, -amount))
                    return false;
                UpdateBalance(to, +amount);
            }
            PostTransfer(from, to, amount, data);
            return true;
        }
    }
}
