package com.app;
//класс, проверяющий, какие комбинации подходят

public class FindVariants {
    private int ans;
    private int[] arr;
    FindVariants(int ans, int[] arr){
        this.ans=ans;
        this.arr=arr;
    }
    public String findVariants() {
        //ищем все варианты
        PermutationsWithRepetition gen = new PermutationsWithRepetition(
                new char[]{'-', '+', '/', '*'},
                arr.length - 1);
        char[][] variations = gen.getVariations();  //получили все возможные ккомбинации из "-", "+", "/", "*"

        //для подсчёта значения выражения
        Calc c=new Calc();

        //ищем подходящие комбинации

        String resStr = "";
        String calcStr;
        for (char [] variation : variations) {  //проходим по всем комбинациям
            int j = 0; //индекс позиции в комбинации.

            //собираем выражение в одну строку
            calcStr=String.valueOf(arr[0]); // первый символ строки это первая цифра
            for (int i = 1; i < arr.length; i++) {  //цикл по числам, для которых нужно подобрать знаки
                switch (variation[j]) {   //добавляем знаки
                    case '+':
                        calcStr = calcStr+ '+'+ String.valueOf(arr[i]);
                        break;
                    case '-':
                        calcStr = calcStr +'-'+ String.valueOf(arr[i]);
                        break;
                    case '*':
                        calcStr = calcStr +'*'+ String.valueOf(arr[i]);
                        break;
                    case '/':
                        calcStr = calcStr +'/'+ arr[i];
                        break;
                }
                j++;
            }
            String res=c.calc(calcStr);  //получившуюся строку считаем

            //если полученнный ответ и требуемый равны, то запоминаем комбинацию в resStr
            if (Character.isDigit(res.toCharArray()[0]))
                if (Integer.parseInt(res) == ans) {
                    resStr += calcStr + " = " + ans + "\n";
                }
        }
        return resStr;
    }
}
