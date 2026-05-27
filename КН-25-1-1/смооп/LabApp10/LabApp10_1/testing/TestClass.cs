using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_1.things;
using LabApp10_1.testing.actions;

namespace LabApp10_1.testing {

    internal class TestClass
    {
     public static void ExecuteTests()
        {
            DateAction.DoDateTest();
            NumbersAction.DoNumbersTest();
            GeometryAction.DoGeometryTest();
        }
    }
}