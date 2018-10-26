# NET1.A.2018.Golovach.03 - (deadline 17.10.2018, 24.00)

# Задание

Внести правки по выполненным ранее задачам с учетом замечаний.

(deadline 17.10.2018, 24.00) Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью.
Разработать модульные тесты (NUnit и MS Unit Test (используя подход DDT)) для тестирования метода. Примерные тест кейсы:
-  [TestCase(1, 5, 0.0001,ExpectedResult =1)]
- ul [TestCase(8, 3, 0.0001,ExpectedResult = 2)]
- ul [TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]
- ul [TestCase(0.04100625,4 , 0.0001, ExpectedResult =0.45)]
- ul [TestCase(8, 3, 0.0001, ExpectedResult =2)]
- ul [TestCase(0.0279936, 7, 0.0001, ExpectedResult =0.6)]
- ul [TestCase(0.0081, 4, 0.1, ExpectedResult =0.3)]
- ul [TestCase(-0.008, 3, 0.1, ExpectedResult =-0.2)]
- ul [TestCase(0.004241979, 9, 0.00000001, ExpectedResult =0.545)]
- ul [a = -0.01, n = 2, accurancy = 0.0001] <- ArgumentException
- ul [a = 0.001, n = -2, accurancy = 0.0001] <- ArgumentException
- ul [a = 0.01, n = 2, accurancy = -1] <- ArgumentException

 Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.
Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода. Примерные тест-кейсы
- ul [TestCase(12, ExpectedResult = 21)]
- ul [TestCase(513, ExpectedResult = 531)]
- ul [TestCase(2017, ExpectedResult = 2071)]
- ul[TestCase(414, ExpectedResult = 441)]
- ul [TestCase(144, ExpectedResult = 414)]
- ul [TestCase(1234321, ExpectedResult = 1241233)]
- ul [TestCase(1234126, ExpectedResult = 1234162)]
- ul [TestCase(3456432, ExpectedResult = 3462345)]
- ul [TestCase(10, ExpectedResult = -1)]
- ul [TestCase(20, ExpectedResult = -1)]
