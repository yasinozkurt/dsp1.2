using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsProject2._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Program başlatıldı...");
            Console.WriteLine();



            double[,] veriSeti = { {6,5,1 }, {2,4,1 }, {-3,-5,-1 }, {-1,-1,-1 }, {1,1,1 }, {-2,7,1 }, {-4,-2,-1 }, {-6,3,-1 } };
            //Halihazırda 1 tur dönmeye ayarlı 'Learn' metodunu for içinde istediğimiz epok değerinde kullanabiliriz
            int epoch = 100;

            Neuron nöron1 = new Neuron();

            for(int i = 0; i < epoch; i++)
            {
                nöron1.Learn(veriSeti);
                Console.WriteLine((i + 1) + ". epok için doğruluk değeri:");
                Console.WriteLine("#######################################");




            }




            Console.Read();
        }
    }


    class Neuron
    {
        private double w1;
        private double w2;
        private double learingRate = 0.05;


        public Neuron()
        {
            Random r = new Random();
            //
            this.w1 = r.NextDouble() * (double)(2)-(double)1;
            this.w2 = r.NextDouble() * (double)(2)-(double)1;
        }


        public void Learn(double[,] trainSet)
        {
            double valueY = 0;
            int CorrectAnsw = 0;
            int WrongAnsw = 0;
            double accuracy;

            
            //eğitim setindeki verileri sırayla alıp işliyoruz
            for(int i=0;i< trainSet.GetLength(0); i++)
            {
                double x1 = trainSet[i,0] /10;
                double x2 = trainSet[i,1] /10;

                //Calculation Section
                Console.WriteLine("w1 ve w2:    " + this.w1 + " " + this.w2);
                double sum = ((x1) * this.w1) + ((x2) * this.w2);
                Console.WriteLine("sum: " + sum);

                if (sum < 0.5)
                {
                    valueY = -1;

                }
                else if (sum >= 0.5)
                {
                    valueY = 1;
                }

                Console.WriteLine("target:" + trainSet[i, 2]);
                Console.WriteLine("value we found" + valueY);


                //Learning Section
                //bulunan değer hedef değerden büyükse: 
                if (trainSet[i,2] < valueY)
                {
                    this.w1 = this.w1 - (learingRate * (trainSet[i,2] - valueY) * (double)(x1));
                    this.w2 = this.w2 - (learingRate * (trainSet[i,2] - valueY) * (double)(x2 ));
                    WrongAnsw++;
                    Console.WriteLine("wa");
                    

                }
                else if(trainSet[i,2]> valueY)
                {
                    this.w1 = this.w1 + (learingRate * (trainSet[i,2] - valueY) * (double)(x1));
                    this.w2 = this.w2 + (learingRate * (trainSet[i,2] - valueY) * (double)(x2));
                    WrongAnsw++;
                    Console.WriteLine("wa2");
                }
                else
                {
                    CorrectAnsw++;
                    Console.WriteLine("ca");
                }




            }

            //doğruluk değeri:
            
          
            Console.WriteLine();
            accuracy = (double)CorrectAnsw / (double)(CorrectAnsw + WrongAnsw);
            Console.WriteLine("#######################################");


            Console.WriteLine("Accuracy: %" + (double)accuracy*100);
            Console.WriteLine();

           




        }
    }
}
