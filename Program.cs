using System;
using System.Collections.Generic;

namespace Calculadora_991_MS
{
    static class Program
    {
        static double Ans = 0.0;
        static bool IsDegreeMode = true; // true = DEG, false = RAD
        static readonly Dictionary<char, double> Variables = new()
        {
            { 'A', 0.0 }, { 'B', 0.0 }, { 'C', 0.0 }, { 'D', 0.0 },
            { 'E', 0.0 }, { 'F', 0.0 }, { 'X', 0.0 }, { 'Y', 0.0 },
            { 'M', 0.0 }
        };

        static void Main()
        {
            Console.Title = "Simulador Calculadora Casio fx-991MS";
            bool keepRunning = true;

            while (keepRunning)
            {
                DisplayCalculatorState();
                ShowMainMenu();
                string? choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            DoBasicArithmetic();
                            break;
                        case "2":
                            DoPowerAndRoots();
                            break;
                        case "3":
                            DoTrigonometry();
                            break;
                        case "4":
                            DoHyperbolic();
                            break;
                        case "5":
                            DoExponentialAndLog();
                            break;
                        case "6":
                            DoCombinatoricsAndFactorial();
                            break;
                        case "7":
                            DoCoordinateConversion();
                            break;
                        case "8":
                            DoMemoryOperations();
                            break;
                        case "9":
                            IsDegreeMode = !IsDegreeMode;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nModo de ángulo cambiado a: {(IsDegreeMode ? "GRADOS (DEG)" : "RADIANES (RAD)")}");
                            Console.ResetColor();
                            Pause();
                            break;
                        case "10":
                            ClearVariablesAndAns();
                            break;
                        case "11":
                            keepRunning = false;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n¡Gracias por usar el Simulador fx-991MS! Hasta luego.");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                            Console.ResetColor();
                            Pause();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nError: {ex.Message}");
                    Console.ResetColor();
                    Pause();
                }
            }
        }

        static void DisplayCalculatorState()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                SIMULADOR DE CALCULADORA CASIO fx-991MS                  ");
            Console.WriteLine("==========================================================================");
            Console.ResetColor();

            // Modo actual (DEG/RAD)
            Console.Write(" Modo de Ángulo: ");
            Console.ForegroundColor = ConsoleColor.Black;
            if (IsDegreeMode)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("  DEG  ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("  RAD  ");
            }
            Console.ResetColor();
            Console.WriteLine();

            // Variables y sus valores actuales
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write(" Variables: ");
            int count = 0;
            foreach (var kvp in Variables)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{kvp.Key}=");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{kvp.Value:G6}   ");
                count++;
                if (count == 5) Console.Write("\n            ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ResetColor();

            // Pantalla (Display) del resultado previo Ans
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" [Ans] = ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Ans:G15}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==========================================================================");
            Console.ResetColor();
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("Seleccione una categoría de funciones:");
            Console.WriteLine(" 1. Aritmética Básica y Recíproco (+, -, *, /, %, x⁻¹)");
            Console.WriteLine(" 2. Potencias y Raíces (x², x³, x^y, √, ³√, y√x)");
            Console.WriteLine(" 3. Trigonometría e Inversas (sin, cos, tan, sin⁻¹, cos⁻¹, tan⁻¹)");
            Console.WriteLine(" 4. Funciones Hiperbólicas (sinh, cosh, tanh, sinh⁻¹, cosh⁻¹, tanh⁻¹)");
            Console.WriteLine(" 5. Exponenciales y Logaritmos (ln, log₁₀, e^x, 10^x)");
            Console.WriteLine(" 6. Combinatoria y Factorial (x!, nPr, nCr)");
            Console.WriteLine(" 7. Conversión de Coordenadas (Pol, Rec)");
            Console.WriteLine(" 8. Operaciones de Memoria (STO, RCL, M+, M-)");
            Console.WriteLine(" 9. Cambiar Modo de Ángulo [DEG / RAD]");
            Console.WriteLine("10. Limpiar Memoria y Ans");
            Console.WriteLine("11. Salir");
            Console.Write("\nElija una opción (1-11): ");
        }

        static void DoBasicArithmetic()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- ARITMÉTICA BÁSICA ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. Suma (+), 2. Resta (-), 3. Multiplicación (*), 4. División (/), 5. Residuo (%), 6. Recíproco (1/x)");
            Console.Write("Seleccione operación (1-6): ");
            string? op = Console.ReadLine();

            double a, b, result = 0.0;
            switch (op)
            {
                case "1":
                    a = PromptValue("Ingrese primer número (o variable): ");
                    b = PromptValue("Ingrese segundo número (o variable): ");
                    result = a + b;
                    Console.WriteLine($"\nResultado: {a} + {b} = {result}");
                    break;
                case "2":
                    a = PromptValue("Ingrese primer número (o variable): ");
                    b = PromptValue("Ingrese segundo número (o variable): ");
                    result = a - b;
                    Console.WriteLine($"\nResultado: {a} - {b} = {result}");
                    break;
                case "3":
                    a = PromptValue("Ingrese primer número (o variable): ");
                    b = PromptValue("Ingrese segundo número (o variable): ");
                    result = a * b;
                    Console.WriteLine($"\nResultado: {a} * {b} = {result}");
                    break;
                case "4":
                    a = PromptValue("Ingrese dividendo (o variable): ");
                    b = PromptValue("Ingrese divisor (o variable): ");
                    if (b == 0) throw new DivideByZeroException("División por cero detectada.");
                    result = a / b;
                    Console.WriteLine($"\nResultado: {a} / {b} = {result}");
                    break;
                case "5":
                    a = PromptValue("Ingrese base (o variable): ");
                    b = PromptValue("Ingrese módulo (o variable): ");
                    result = a % b;
                    Console.WriteLine($"\nResultado: {a} % {b} = {result}");
                    break;
                case "6":
                    a = PromptValue("Ingrese x para calcular 1/x: ");
                    if (a == 0) throw new DivideByZeroException("Recíproco de cero indefinido.");
                    result = 1.0 / a;
                    Console.WriteLine($"\nResultado: 1 / {a} = {result}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoPowerAndRoots()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- POTENCIAS Y RAÍCES ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. x² (Cuadrado), 2. x³ (Cubo), 3. x^y (Potencia), 4. √x (Raíz Cuadrada), 5. ³√x (Raíz Cúbica), 6. y√x (Raíz y-ésima)");
            Console.Write("Seleccione operación (1-6): ");
            string? op = Console.ReadLine();

            double x, y, result = 0.0;
            switch (op)
            {
                case "1":
                    x = PromptValue("Ingrese x: ");
                    result = x * x;
                    Console.WriteLine($"\nResultado: {x}² = {result}");
                    break;
                case "2":
                    x = PromptValue("Ingrese x: ");
                    result = x * x * x;
                    Console.WriteLine($"\nResultado: {x}³ = {result}");
                    break;
                case "3":
                    x = PromptValue("Ingrese base x: ");
                    y = PromptValue("Ingrese exponente y: ");
                    result = Math.Pow(x, y);
                    Console.WriteLine($"\nResultado: {x}^{y} = {result}");
                    break;
                case "4":
                    x = PromptValue("Ingrese x (debe ser >= 0): ");
                    if (x < 0) throw new ArgumentException("La raíz cuadrada de un número negativo no es real.");
                    result = Math.Sqrt(x);
                    Console.WriteLine($"\nResultado: √({x}) = {result}");
                    break;
                case "5":
                    x = PromptValue("Ingrese x: ");
                    result = Math.Cbrt(x);
                    Console.WriteLine($"\nResultado: ³√({x}) = {result}");
                    break;
                case "6":
                    x = PromptValue("Ingrese x: ");
                    y = PromptValue("Ingrese índice y de la raíz y√x: ");
                    if (y == 0) throw new ArgumentException("El índice de la raíz no puede ser cero.");
                    if (x < 0 && Math.Abs(y % 2) < double.Epsilon) throw new ArgumentException("La raíz par de un número negativo no es real.");
                    result = Math.Pow(x, 1.0 / y);
                    Console.WriteLine($"\nResultado: {y}√({x}) = {result}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoTrigonometry()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- TRIGONOMETRÍA E INVERSAS ---");
            Console.ResetColor();
            Console.WriteLine($"Modo de ángulo actual: {(IsDegreeMode ? "DEG (Grados)" : "RAD (Radianes)")}");
            Console.WriteLine("Funciones: 1. sin(x), 2. cos(x), 3. tan(x), 4. sin⁻¹(x), 5. cos⁻¹(x), 6. tan⁻¹(x)");
            Console.Write("Seleccione operación (1-6): ");
            string? op = Console.ReadLine();

            double x, result = 0.0;
            switch (op)
            {
                case "1":
                    x = PromptValue("Ingrese ángulo x: ");
                    double rad1 = IsDegreeMode ? DegToRad(x) : x;
                    result = Math.Sin(rad1);
                    Console.WriteLine($"\nResultado: sin({x}{(IsDegreeMode ? "°" : " rad")}) = {result}");
                    break;
                case "2":
                    x = PromptValue("Ingrese ángulo x: ");
                    double rad2 = IsDegreeMode ? DegToRad(x) : x;
                    result = Math.Cos(rad2);
                    Console.WriteLine($"\nResultado: cos({x}{(IsDegreeMode ? "°" : " rad")}) = {result}");
                    break;
                case "3":
                    x = PromptValue("Ingrese ángulo x: ");
                    double rad3 = IsDegreeMode ? DegToRad(x) : x;
                    // Verificar si tan es indefinido (ej: 90 grados, 270 grados, pi/2 radianes, etc.)
                    if (IsDegreeMode && Math.Abs((x - 90) % 180) < 0.0001)
                    {
                        throw new ArgumentException("Tangente indefinida para este ángulo.");
                    }
                    result = Math.Tan(rad3);
                    Console.WriteLine($"\nResultado: tan({x}{(IsDegreeMode ? "°" : " rad")}) = {result}");
                    break;
                case "4":
                    x = PromptValue("Ingrese valor x [-1 a 1]: ");
                    if (x < -1.0 || x > 1.0) throw new ArgumentException("El argumento de sin⁻¹ debe estar entre -1 y 1.");
                    result = Math.Asin(x);
                    if (IsDegreeMode) result = RadToDeg(result);
                    Console.WriteLine($"\nResultado: sin⁻¹({x}) = {result}{(IsDegreeMode ? "°" : " rad")}");
                    break;
                case "5":
                    x = PromptValue("Ingrese valor x [-1 a 1]: ");
                    if (x < -1.0 || x > 1.0) throw new ArgumentException("El argumento de cos⁻¹ debe estar entre -1 y 1.");
                    result = Math.Acos(x);
                    if (IsDegreeMode) result = RadToDeg(result);
                    Console.WriteLine($"\nResultado: cos⁻¹({x}) = {result}{(IsDegreeMode ? "°" : " rad")}");
                    break;
                case "6":
                    x = PromptValue("Ingrese valor x: ");
                    result = Math.Atan(x);
                    if (IsDegreeMode) result = RadToDeg(result);
                    Console.WriteLine($"\nResultado: tan⁻¹({x}) = {result}{(IsDegreeMode ? "°" : " rad")}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoHyperbolic()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- FUNCIONES HIPERBÓLICAS ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. sinh(x), 2. cosh(x), 3. tanh(x), 4. sinh⁻¹(x), 5. cosh⁻¹(x), 6. tanh⁻¹(x)");
            Console.Write("Seleccione operación (1-6): ");
            string? op = Console.ReadLine();

            double x, result = 0.0;
            switch (op)
            {
                case "1":
                    x = PromptValue("Ingrese x: ");
                    result = Math.Sinh(x);
                    Console.WriteLine($"\nResultado: sinh({x}) = {result}");
                    break;
                case "2":
                    x = PromptValue("Ingrese x: ");
                    result = Math.Cosh(x);
                    Console.WriteLine($"\nResultado: cosh({x}) = {result}");
                    break;
                case "3":
                    x = PromptValue("Ingrese x: ");
                    result = Math.Tanh(x);
                    Console.WriteLine($"\nResultado: tanh({x}) = {result}");
                    break;
                case "4":
                    x = PromptValue("Ingrese x: ");
                    result = Math.Log(x + Math.Sqrt((x * x) + 1.0));
                    Console.WriteLine($"\nResultado: sinh⁻¹({x}) = {result}");
                    break;
                case "5":
                    x = PromptValue("Ingrese x (debe ser >= 1): ");
                    if (x < 1.0) throw new ArgumentException("El argumento de cosh⁻¹ debe ser >= 1.");
                    result = Math.Log(x + Math.Sqrt((x * x) - 1.0));
                    Console.WriteLine($"\nResultado: cosh⁻¹({x}) = {result}");
                    break;
                case "6":
                    x = PromptValue("Ingrese x (debe estar en el rango (-1, 1)): ");
                    if (x <= -1.0 || x >= 1.0) throw new ArgumentException("El argumento de tanh⁻¹ debe estar entre -1 y 1.");
                    result = 0.5 * Math.Log((1.0 + x) / (1.0 - x));
                    Console.WriteLine($"\nResultado: tanh⁻¹({x}) = {result}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoExponentialAndLog()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- EXPONENCIALES Y LOGARITMOS ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. ln(x) (Natural Log), 2. log(x) (Base 10), 3. e^x (Exponencial Natural), 4. 10^x (Base 10 Exponencial)");
            Console.Write("Seleccione operación (1-4): ");
            string? op = Console.ReadLine();

            double x, result = 0.0;
            switch (op)
            {
                case "1":
                    x = PromptValue("Ingrese x (debe ser > 0): ");
                    if (x <= 0) throw new ArgumentException("El argumento de ln debe ser estrictamente positivo.");
                    result = Math.Log(x);
                    Console.WriteLine($"\nResultado: ln({x}) = {result}");
                    break;
                case "2":
                    x = PromptValue("Ingrese x (debe ser > 0): ");
                    if (x <= 0) throw new ArgumentException("El argumento de log₁₀ debe ser estrictamente positivo.");
                    result = Math.Log10(x);
                    Console.WriteLine($"\nResultado: log₁₀({x}) = {result}");
                    break;
                case "3":
                    x = PromptValue("Ingrese exponente x: ");
                    result = Math.Exp(x);
                    Console.WriteLine($"\nResultado: e^{x} = {result}");
                    break;
                case "4":
                    x = PromptValue("Ingrese exponente x: ");
                    result = Math.Pow(10.0, x);
                    Console.WriteLine($"\nResultado: 10^{x} = {result}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoCombinatoricsAndFactorial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- COMBINATORIA Y FACTORIAL ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. x! (Factorial), 2. nPr (Permutaciones), 3. nCr (Combinaciones)");
            Console.Write("Seleccione operación (1-3): ");
            string? op = Console.ReadLine();

            double n, r, result = 0.0;
            switch (op)
            {
                case "1":
                    n = PromptValue("Ingrese número x (entero no negativo, máximo 170): ");
                    result = Factorial(n);
                    Console.WriteLine($"\nResultado: {n}! = {result}");
                    break;
                case "2":
                    n = PromptValue("Ingrese número n (total elementos): ");
                    r = PromptValue("Ingrese número r (elementos a elegir): ");
                    result = Permutation(n, r);
                    Console.WriteLine($"\nResultado: {n} P {r} = {result}");
                    break;
                case "3":
                    n = PromptValue("Ingrese número n (total elementos): ");
                    r = PromptValue("Ingrese número r (elementos a elegir): ");
                    result = Combination(n, r);
                    Console.WriteLine($"\nResultado: {n} C {r} = {result}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Ans = result;
            Pause();
        }

        static void DoCoordinateConversion()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- CONVERSIÓN DE COORDENADAS ---");
            Console.ResetColor();
            Console.WriteLine("Funciones: 1. Pol(x, y) (Rectangular a Polar), 2. Rec(r, θ) (Polar a Rectangular)");
            Console.Write("Seleccione operación (1-2): ");
            string? op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    double x = PromptValue("Ingrese coordenada X: ");
                    double y = PromptValue("Ingrese coordenada Y: ");
                    double r = Math.Sqrt((x * x) + (y * y));
                    double theta = Math.Atan2(y, x);
                    if (IsDegreeMode) theta = RadToDeg(theta);

                    Variables['X'] = r;
                    Variables['Y'] = theta;
                    Ans = r;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPol({x}, {y}) calculado exitosamente!");
                    Console.ResetColor();
                    Console.WriteLine($"Radio (r) = {r:G6} -> Guardado en la variable [X]");
                    Console.WriteLine($"Ángulo (θ) = {theta:G6}{(IsDegreeMode ? "°" : " rad")} -> Guardado en la variable [Y]");
                    break;

                case "2":
                    double radius = PromptValue("Ingrese Radio (r): ");
                    double angle = PromptValue("Ingrese Ángulo (θ): ");
                    double radAngle = IsDegreeMode ? DegToRad(angle) : angle;
                    double outX = radius * Math.Cos(radAngle);
                    double outY = radius * Math.Sin(radAngle);

                    Variables['X'] = outX;
                    Variables['Y'] = outY;
                    Ans = outX;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nRec({radius}, {angle}) calculado exitosamente!");
                    Console.ResetColor();
                    Console.WriteLine($"Coordenada X = {outX:G6} -> Guardada en la variable [X]");
                    Console.WriteLine($"Coordenada Y = {outY:G6} -> Guardada en la variable [Y]");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    Pause();
                    return;
            }

            Pause();
        }

        static void DoMemoryOperations()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- OPERACIONES DE MEMORIA Y VARIABLES ---");
            Console.ResetColor();
            Console.WriteLine("Acciones: 1. STO (Guardar Ans en variable), 2. RCL (Recuperar valor), 3. M+ (Sumar a variable M), 4. M- (Restar de variable M)");
            Console.Write("Seleccione acción (1-4): ");
            string? action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    Console.Write("Seleccione variable para guardar (A, B, C, D, E, F, X, Y, M): ");
                    char varStore = char.ToUpper((Console.ReadLine() ?? "").Trim()[0]);
                    if (Variables.ContainsKey(varStore))
                    {
                        Variables[varStore] = Ans;
                        Console.WriteLine($"\nGuardado: {varStore} = Ans ({Ans})");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nVariable no válida.");
                        Console.ResetColor();
                    }
                    break;
                case "2":
                    Console.Write("Seleccione variable a recuperar (A, B, C, D, E, F, X, Y, M): ");
                    char varRec = char.ToUpper((Console.ReadLine() ?? "").Trim()[0]);
                    if (Variables.TryGetValue(varRec, out double valRec))
                    {
                        Ans = valRec;
                        Console.WriteLine($"\nRecuperado: Ans = {varRec} ({Ans})");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nVariable no válida.");
                        Console.ResetColor();
                    }
                    break;
                case "3":
                    double addVal = PromptValue("Ingrese valor a sumar a M (o variable): ");
                    Variables['M'] += addVal;
                    Ans = Variables['M'];
                    Console.WriteLine($"\nM+ ejecutado: M es ahora {Variables['M']}");
                    break;
                case "4":
                    double subVal = PromptValue("Ingrese valor a restar de M (o variable): ");
                    Variables['M'] -= subVal;
                    Ans = Variables['M'];
                    Console.WriteLine($"\nM- ejecutado: M es ahora {Variables['M']}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();
                    break;
            }

            Pause();
        }

        static void ClearVariablesAndAns()
        {
            Ans = 0.0;
            char[] keys = ['A', 'B', 'C', 'D', 'E', 'F', 'X', 'Y', 'M'];
            foreach (var key in keys)
            {
                Variables[key] = 0.0;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVariables y Ans limpiadas a 0.0.");
            Console.ResetColor();
            Pause();
        }

        // Funciones auxiliares matemáticas
        static double DegToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        static double RadToDeg(double radians)
        {
            return radians * 180.0 / Math.PI;
        }

        static double Factorial(double val)
        {
            if (val < 0 || val != Math.Floor(val))
                throw new ArgumentException("El factorial requiere un entero no negativo.");
            if (val > 170)
                throw new OverflowException("El valor es demasiado grande para calcular su factorial (máximo 170).");
            double result = 1;
            for (int i = 1; i <= (int)val; i++)
                result *= i;
            return result;
        }

        static double Permutation(double n, double r)
        {
            if (n < 0 || r < 0 || n < r || n != Math.Floor(n) || r != Math.Floor(r))
                throw new ArgumentException("n y r deben ser enteros no negativos con n >= r.");
            return Factorial(n) / Factorial(n - r);
        }

        static double Combination(double n, double r)
        {
            if (n < 0 || r < 0 || n < r || n != Math.Floor(n) || r != Math.Floor(r))
                throw new ArgumentException("n y r deben ser enteros no negativos con n >= r.");
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        static double ResolveValue(string input)
        {
            input = input.Trim().ToUpper();
            if (input == "ANS") return Ans;
            if (input == "PI") return Math.PI;
            if (input == "E") return Math.E;
            if (input.Length == 1 && Variables.TryGetValue(input[0], out double dictVal))
            {
                return dictVal;
            }
            if (double.TryParse(input, out double val))
            {
                return val;
            }
            throw new ArgumentException($"Entrada inválida: '{input}' no es un número ni una variable válida.");
        }

        static double PromptValue(string promptText)
        {
            while (true)
            {
                Console.Write(promptText);
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Por favor, ingrese un valor.");
                    continue;
                }
                try
                {
                    return ResolveValue(input);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
