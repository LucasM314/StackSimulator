﻿using System.Collections;

namespace StackSimulator.OpCodes
{
    public class Sub : IOpCodeHandler
    {
        public void ExecuteInstruction(object operand, ref Stack stack)
        {
            var firstNumber = (int) stack.Pop();
            var secondNumber = (int) stack.Pop();
            stack.Push(secondNumber - firstNumber);
        }
    }
}