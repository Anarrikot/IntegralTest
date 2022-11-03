using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Integral
{
    public class Integrlar_score : ToIntegral
    {
        public Integrlar_score(double a, double b, double n) //Конструктор
        {
            A = a;
            B = b;
            N = n;
        }
        public double Score(int metod, bool test)
        {
            if (N < 0 | A > B)
                throw new ArgumentException();
            if (test)
                if (metod == 0)
                {
                    double step = (B - A) / N;
                    double Sum = 0;
                    for (double i = (A + step * 0.5); i <= B; i += step)
                    {
                        Sum += F(i, test);
                    }
                    return step * Sum;
                }
                else
                {
                    double step = (B - A) / N;
                    double Sum1 = F(A, test) + F(B, test);
                    double Sum2 = 0, Sum3 = 0;
                    for (double i = 1; i <= N / 2; i++)
                        Sum2 += F(A + (2 * i - 1) * step, test);
                    Sum2 *= 4;
                    for (double i = 1; i <= (N / 2 - 1); i++)
                        Sum3 += F(A + 2 * i * step, test);
                    Sum3 *= 2;
                    return step / 3 * (Sum1 + Sum2 + Sum3);
                }
            else
                if (metod == 0)
                {
                    double step = (B - A) / N;
                    double Sum = 0;
                    for (double i = (A + step * 0.5); i <= B; i += step)
                    {
                        Sum += F(i);
                    }
                    return step * Sum;
                }
                else
                {
                double step = (B - A) / N;
                double Sum1 = F(A) + F(B);
                double Sum2 = 0, Sum3 = 0;
                for (double i = 1; i <= N / 2; i++)
                    Sum2 += F(A + (2 * i - 1) * step);
                Sum2 *= 4;
                for (double i = 1; i <= (N / 2 - 1); i++)
                    Sum3 += F(A + 2 * i * step);
                Sum3 *= 2;
                return step / 3 * (Sum1 + Sum2 + Sum3);
                }
        }
    }
}
