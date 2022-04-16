using System.Collections;
using StackSimulator.OpCodes;

namespace StackSimulator
{
    public class Instruction
    {
        private IOpCodeHandler OpCode { get; }
        private object Operand { get; }

        public Instruction(IOpCodeHandler opCode, object operand = null)
        {
            OpCode = opCode;
            Operand = operand;
        }

        public static void EmulateInstruction(Instruction instruction, ref Stack stack) =>
            instruction.OpCode.ExecuteInstruction(instruction.Operand, ref stack);
    }
}