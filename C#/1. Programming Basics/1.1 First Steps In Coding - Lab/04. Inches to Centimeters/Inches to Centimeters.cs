// Да се напише програма, която чете от конзолата реално число и го преобразува от инчове в сантиметри. За целта умножете инчовете по 2.54 (1 инч = 2.54 сантиметра).
double inches = double.Parse(Console.ReadLine());
double centimeters = inches * 2.54;
Console.WriteLine(centimeters);