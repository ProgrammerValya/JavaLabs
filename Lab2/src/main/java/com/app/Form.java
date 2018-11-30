package com.app;

import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Form extends JFrame {

    private JLabel cntLabel;
    private JButton getResult;
    private JLabel answerLabel;
    private JTextArea inputData;
    private JSpinner spinInt;

    //массив введенных рисок
    private int[] arr;

    public Form() {
        super("Пробирки");
        this.setBounds(250,150,600,300);
        //Подготавливаем компоненты объекта
        cntLabel = new JLabel("Выберете количество рисок:");
        getResult = new JButton("Получить результат");
        answerLabel = new JLabel("Введите значения рисок:");
        inputData = new JTextArea();
        SpinnerModel model =
                new SpinnerNumberModel(1, //initial value
                        1, //min
                        20, //max
                        1);   //step
        spinInt   = new JSpinner(model);
        cntLabel.setHorizontalAlignment(JLabel.CENTER);
        answerLabel.setHorizontalAlignment(JLabel.CENTER);

        cntLabel.setFont(new Font("Arial", Font.BOLD, 16));
        answerLabel.setFont(new Font("Arial", Font.BOLD, 16));
        getResult.setFont(new Font("Arial", Font.BOLD, 16));
        inputData.setFont(new Font("Arial", Font.BOLD, 16));
        Border border = BorderFactory.createLineBorder(Color.BLACK);
        inputData.setBorder(BorderFactory.createCompoundBorder(border,
                BorderFactory.createEmptyBorder(10, 10, 10, 10)));

        //Расставляем компоненты по местам
        JPanel panel1 = new JPanel();

        GridBagLayout gbl = new GridBagLayout();
        GridBagConstraints c =  new GridBagConstraints();
        panel1.setLayout(gbl);

        c.anchor = GridBagConstraints.CENTER;
        c.fill   = GridBagConstraints.HORIZONTAL;
        c.gridheight = 1;
        c.gridwidth  = 1;
        c.gridx = 1;
        c.gridy = 1;
        c.insets = new Insets(40, 0, 0, 0);
        c.ipadx = 0;
        c.ipady = 0;
        c.weightx = 1.0;
        c.weighty = 0.0;

        gbl.setConstraints(cntLabel, c);
        add(cntLabel);
        panel1.add(cntLabel);

        c.gridx = 2;
        c.gridy = 1;
        c.fill   = GridBagConstraints.NONE;
        c.ipadx = 20;
        gbl.setConstraints(spinInt, c);
        panel1.add(spinInt);


        c.gridx = 1;
        c.gridy = 2;
        c.ipadx = 0;
        c.fill   =GridBagConstraints.BOTH;
        gbl.setConstraints(answerLabel, c);
        panel1.add(answerLabel);


        c.gridx = 2;
        c.gridy = 2;
        c.fill   =GridBagConstraints.HORIZONTAL;
        c.ipady = 0;
        gbl.setConstraints(inputData, c);
        panel1.add(inputData);


        c.insets = new Insets(40, 0, 40, 0);
        c.gridx = 1;
        c.gridy = 3;
        c.gridwidth  = 2;
        c.ipady = 0;
        c.fill   = GridBagConstraints.NONE;
        gbl.setConstraints(getResult, c);
        panel1.add(getResult);


        panel1.setBorder(BorderFactory.createEmptyBorder(30, 0, 30, 20));
        add(panel1);
        initListeners();

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    private void getData() {
        //читаем числа и заносим их в массив
        String inputStr= inputData.getText();
        inputStr=inputStr.replace("  "," ");
        inputStr=inputStr.trim();
        String[] strNumbers = inputStr.split(" ");
        if (strNumbers.length != Integer.parseInt(spinInt.getValue().toString())) {
            JOptionPane.showMessageDialog(null, "Количество рисок не соответствует заданному");
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

            if ((curNum >= 0) && (curNum <= 100)) {

                arr[i] = curNum;
            }
            else {
                JOptionPane.showMessageDialog(null, "Можно вводить только от 1 до 100 без повторений");
                throw new NullPointerException();
            }
        }
    }

    private void initListeners() {
        getResult.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                getData();
                Task t=new Task(arr);
                int res = t.getAnswer();
                if (res == -1)
                    JOptionPane.showMessageDialog(null,"Нет, невозможно получить 1 мл");
                else
                    JOptionPane.showMessageDialog(null,"Да, можно получить 1 мл.\nКол-во шагов: "+res);
            }
        });
    }

}

