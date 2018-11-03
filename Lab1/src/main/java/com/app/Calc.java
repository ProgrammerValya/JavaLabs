package main.java.com.app;
import java.util.Stack;
//класс для вычисления выражения


public class Calc {

    int i;
    boolean is_op (char c) {
        return c=='+' || c=='-' || c=='*' || c=='/' || c=='%';
    }

    int priority (char op) {
        return
                op == '+' || op == '-' ? 1 :
                        op == '*' || op == '/' ? 2 :
                                -1;
    }

    //выполняет операцию, результат true, если операция прошла успешно
    boolean process_op (Stack st, char op) {
        int r = Integer.parseInt(st.pop().toString());
        int l = Integer.parseInt(st.pop().toString());
        switch (op) {
            case '+':  st.push (l + r);return true;
            case '-':  st.push (l - r);return true;
            case '*':  st.push (l * r);return true;
            case '/':  if ((r!=0) && (l % r==0)){
                        st.push ((int)(l / r));
                        return true;
                        }
                        return false;
            default:return false;
        }
    }

   String calc (String str) {
        Stack st=new Stack();  //стек с числами
        Stack op=new Stack();  //стек с операциями
        char[] s= str.toCharArray();
        for (i=0; i<s.length; i++) //идёи по всей длине сторки
                 if (is_op (s[i])) {  //если это операция
                    char curop = s[i]; //запоминаем эту операцию в curop
                    while ((!op.empty()) && (priority((char)op.peek())>=priority(s[i]))) //пока стек операций не пуст и приоритет нашей поерации ниже
                    {
                        if (!process_op(st, (char) op.pop())) //выполняем предыдущую оерацию в стеке
                            return "ошибка";
                    }
                         op.push (curop); //заносим в стек нашу операцию

                }
                else {   //если у нас не операция
                    String operand="";
                    int j=0;
                    while ((i < s.length)&&(Character.isDigit(s[i])))  //запоминаем оставшуюся строку
                    {
                        operand+= s[i];
                        j++;
                        i++;
                    }
                     --i;

                        st.push (Integer.parseInt(operand));

                }
        while (!op.empty()) {  //После того, как мы обработаем всю строку, в стеке операций ещё могут остаться некоторые
            // операции, которые ещё не были вычислены, и нужно выполнить их все
            if (!process_op(st, (char) op.peek()))
            return "ошибка";
            op.pop();
        }
        if (!st.isEmpty()) return st.peek().toString();
        else return "ошибка";
    }
}
