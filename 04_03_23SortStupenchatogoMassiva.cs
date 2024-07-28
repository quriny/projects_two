namespace _040323.Homework.SortirovkaStupenchatogoMassiva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] arrTaxi = new int[10][];

            arrTaxi[0] = new int[] { 100, 289, 200, 101, 90, 230 };
            arrTaxi[1] = new int[] { 290, 300, 303, 120, 150 };
            arrTaxi[2] = new int[] { 80 };
            arrTaxi[3] = new int[] { 300, 60, 120, 400, 410 };
            arrTaxi[4] = new int[] { 60, 100, 40 };
            arrTaxi[5] = new int[] { 60, 160, 165, 120, 110, 230, 200, 30 };
            arrTaxi[6] = new int[] { 230, 200, 250, 100 };
            arrTaxi[7] = new int[] { 100, 209, 175, 100 };
            arrTaxi[8] = new int[] { 70, 120, 290 };
            arrTaxi[9] = new int[] { 90, 80, 105, 140, 120 };

            int[] maxLength;

            for (int i=0;i<arrTaxi.Length;++i) {
                maxLength=arrTaxi[i];
                for (int j = i+1; j < arrTaxi.Length; ++j)
                {
                    if (arrTaxi[j].Length>maxLength.Length)
                    {

                        maxLength=arrTaxi[j];
                        arrTaxi[j]=arrTaxi[i];

                    }else
                    {
                        if (arrTaxi[j].Sum() > maxLength.Sum())
                        {
                            maxLength = arrTaxi[j];
                            arrTaxi[j] = arrTaxi[i];
                        }
                    }
                }
                arrTaxi[i]= maxLength;
            }



            //int[] arr= arrTaxi[0];
            //for (int i=0;i<arrTaxi.Length;++i)
            //{
            //    if (arrTaxi[i].Length>arr.Length)
            //    {
            //        arr= arrTaxi[i];
            //    }
            //}
            //arrTaxi[0] = arr;            


            for (int i = 0; i < arrTaxi.Length; ++i)
            {
                for (int j = 0; j < arrTaxi[i].Length; ++j)
                {
                    Console.Write(arrTaxi[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}