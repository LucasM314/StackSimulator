using System;
using System.Collections;
using System.Linq;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using StackSimulator.OpCodes;

namespace StackSimulator
{
    public class MethodEmulator
    {
        private MethodDefinition MethodToEmulate { get; }
        public Stack Stack = new();
        
        public MethodEmulator(MethodDefinition methodToEmulate) => MethodToEmulate = methodToEmulate;
        
        public void Emulate()
        {
            foreach (var instr in MethodToEmulate.CilMethodBody.Instructions.Select(instruction =>
                         new Instruction(ResolveOpCode(instruction.OpCode.Code), instruction.Operand)))
            {
                Instruction.EmulateInstruction(instr, ref Stack);
            }
        }
        
        private static IOpCodeHandler ResolveOpCode(CilCode opCode) => opCode switch
        {
            CilCode.Ldc_I4 => new LdcI4(),
            CilCode.Add => new Add(),
            CilCode.Sub => new Sub(),
            CilCode.Mul => new Mul(),
            CilCode.Div => new Div(),
            CilCode.Ret => new Ret(),
            _ => throw new ArgumentOutOfRangeException(nameof(opCode), opCode, null)
        };
    }
}