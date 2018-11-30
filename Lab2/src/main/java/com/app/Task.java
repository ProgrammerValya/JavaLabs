package com.app;
import java.io.FileWriter;
import java.io.IOException;

public class Task {
    private int maxMark=100; //максимальное количество мл
    private int N, step; //N-количество рисок, step-количество шагов
    private int[] mark; //Массив из значений рисок
    private boolean[][]A=new boolean[maxMark+1][maxMark+1]; //А-массив, отражающий все возможные состояния набора из 2 пробирок
                                                //Если состояние возможно, то соотвествующая ячейка массива true
    private boolean[][]OA=new boolean[maxMark+1][maxMark+1];// OA-массив, отражающий состояния, в которые можно перейти за одно переливание.
                                                            //(вспомогательный массив)
    private boolean isEnd, isFind ; //isEnd-все варинты просмотрены. isFind-найдено решение
    private String[] mas=new String[100];
    Task(int[] inputArr){

        mark=new int[inputArr.length+1];
        mark[0]=0;
        int j=1;
        for (int i=0;i<inputArr.length;i++)
            mark[j++]=inputArr[i];

        N=mark.length;

        //изначально возможно только одно состояние. В певром 100 мл, во втором 0.
        for (int i=0;i<=maxMark;i++)
        {
            for(j=0;j<=maxMark-i;j++)
                A[i][j]=false;
        }
        A[maxMark][0] = true;

        step=0;
        mas[0]="Шаг "+Integer.toString(step)+"\n"+"100 0"+"\n";
    }

    //метод проверяет, возможно ли x мл в первом сосуде, и y во втором.
    //Если возможно, то соответвующая ячейка массива меняетя на true
    void check(int x,int y)
    {
        if ((x>=0) && (y>=0) && (x+y<=100)) {
            if (!A[x][y]) {
                A[x][y] = true;
                mas[step]= mas[step]+Integer.toString(x)+" "+Integer.toString(y)+" "+Integer.toString(100-x-y)+"\n";
                if (x + y == maxMark - 1) {
                    isFind = true; //как только в первом и втором сосуде 99 мл, то решение найдено
                    mas[step+1]="Итог: "+Integer.toString(x)+" "+Integer.toString(y)+" "+Integer.toString(100-x-y);
                }
                isEnd = false;
            }
        }
    }

    //основной метод, решающий задачу
    private void getResult(){
        step++;
        mas[step]= "\n"+"Шаг "+Integer.toString(step)+"\n";
        isEnd = true;
        isFind = false;
       for (int i=0;i<A.length;i++)
           for (int j=0;j<A.length;j++){
           OA[i][j] = A[i][j];
       }
        for (int i=0; i<=maxMark; i++)
            for (int j=0; j<=maxMark-i;j++)
                if (OA[i][j])
                {

                    // если перельем из все из третьего сосуда во второй
                    check(i, 100 - i);
                    //если перельем все из третьего сосуда в первый
                    check(100 - j, j);
                    //рассмотрим каждую риску отдельно
                    for (int k=0; k<N ;k++)
                    {
                        //если переливаем из второго в третий
                        check(i, mark[k]);
                        //из первого в третий
                        check(mark[k], j);
                        //из второго в первый
                        check(i + j - mark[k], mark[k]);
                        //из первого во второй
                        check(mark[k], i + j - mark[k]);
                    }

                }

        if (!(isEnd || isFind)) getResult() ;
    }

    public int getAnswer(){
        getResult();
        try(FileWriter writer = new FileWriter("test.txt", false))
        {
            for (int i = 0; i <= step + 1; i++)
                writer.write(mas[i]);
            writer.flush();
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
        if (isFind) return step; else
            return -1;

    }

}
