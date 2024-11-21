using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

using System;
using System.ComponentModel;
using System.Numerics;

namespace Neo.SmartContract.Template
{
    [DisplayName(nameof(Sazz)+"2")]
    [ContractAuthor("<Your Name Or Company Here>", "<Your Public Email Here>")]
    [ContractDescription( "<Description Here>")]
    [ContractVersion("<Version String Here>")]
    [ContractSourceCode("https://github.com/neo-project/neo-devpack-dotnet/tree/master/src/Neo.SmartContract.Template/templates/neocontractnep17/Sazz.cs")]
    [ContractPermission(Permission.Any, Method.Any)]
    [SupportedStandards(NepStandard.Nep17)]
    public partial class Sazz : Nep17Token
    {
        public static void Reset(UInt160 player)
        {
            ExecutionEngine.Assert(Runtime.CallingScriptHash == GetCoach(), "?");
            ExecutionEngine.Assert(Runtime.CheckWitness(Runtime.CallingScriptHash), "??");

            Nep17Token.Burn(player, BalanceOf(player));
        }

        public static void MintAndTransfer(UInt160 to, BigInteger amount)
        {
            ExecutionEngine.Assert(Runtime.CallingScriptHash == GetCoach(), "?");
            ExecutionEngine.Assert(Runtime.CheckWitness(Runtime.CallingScriptHash), "??");

            Nep17Token.Mint(to, amount);
        }
    }
}
