using ExamStuff_1;
using ExamStuff_1.interfaces;

IFoo t = new Tester();
t.Execute();

//Tester talt = new Tester();
//((IFoo)talt).Execute();

IBar b = new Tester();
b.Execute();

//((IBar)balt).Execute();
