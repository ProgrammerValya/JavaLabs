package main.java.com.app;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Form extends JFrame {

    private JLabel inputLabel;
    private JTextField inputNumbers;
    private JButton getResult;
    private JTextArea resultField;
    private JLabel answerLabel;
    private JTextField inputAnswer;

    //требуемый ответ
    private int ans;
    //исходные числа
    private int[] arr;

    public Form() {
        super("Расстановка знаков");
        //Подготавливаем компоненты объекта
        inputLabel = new JLabel("Введите числа:");
        getResult = new JButton("Получить результат");
        answerLabel = new JLabel("Введите требуемый ответ:");
        inputAnswer = new JTextField(10);
        resultField = new JTextArea(2,2);
        inputNumbers = new JTextField(10);
        //Подготавливаем временные компоненты
        JPanel panel1 = new JPanel();

        //Расставляем компоненты по местам
        panel1.setLayout(new GridLayout(3,3));

        panel1.add(inputLabel);
        panel1.add(inputNumbers);
        panel1.add(answerLabel);
        panel1.add(inputAnswer);
        panel1.add(getResult);
        panel1.add(resultField);

        add(panel1);

        initListeners();
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

    }

    private void getData() {
        //читаем числа и заносим их в массив
        String inputStr= inputNumbers.getText();
        inputStr=inputStr.replace("  "," ");
        String[] strNumbers = inputStr.split(" ");

        if (strNumbers.length == 0) {
            JOptionPane.showMessageDialog(null, "Введите исходные числа");
            throw new NullPointerException();
        }
        arr = new int[strNumbers.length];
        int curNum;
        for (int i = 0; i < strNumbers.length; i++) {
                try {
                    curNum=Integer.parseInt(strNumbers[i]);
                }
                catch (Exception d){
                    JOptionPane.showMessageDialog(null, "Ошибка ввода");
                    throw new NullPointerException();
                }
                if (curNum >= 0) arr[i] = Integer.parseInt(strNumbers[i]);
                else {
                    JOptionPane.showMessageDialog(null, "Можно вводить только числа без знаков");
                    throw new NullPointerException();
                }
            }

        //читаем требуемый ответ
        if (inputAnswer.getText().trim().length() > 0) ;
        else {
            JOptionPane.showMessageDialog(null, "Введите ответ");
            throw new NullPointerException();
        }
        try {
                ans = Integer.parseInt(inputAnswer.getText().trim());
            }
        catch(Exception d){
                JOptionPane.showMessageDialog(null, "Можно вводить только целые числа в ответ");
                throw new NullPointerException();
            }
    }

    private void initListeners() {
        getResult.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                getData();
                FindVariants func = new FindVariants(ans, arr);
                String str = func.findVariants();
                if (str.length() == 0)
                    resultField.setText("Невозможно получить ответ");
                else
                    resultField.setText(str);
            }
        });
    }
}

