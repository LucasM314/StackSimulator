using System.Collections;

namespace StackSimulator.OpCodes
{
    public class LdcI4 : IOpCodeHandler
    {
        public void ExecuteInstruction(object operand, ref Stack stack)
        {
            stack.Push(operand);
        }
    }
}