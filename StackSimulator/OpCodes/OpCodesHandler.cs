using System.Collections;

namespace StackSimulator.OpCodes
{
    public interface IOpCodeHandler
    {
        public void ExecuteInstruction(object operand, ref Stack stack);
    }
}