package com.app;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JButton;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.JScrollPane;
import javax.swing.BorderFactory;
import javax.swing.JOptionPane;
import java.awt.Font;
import java.awt.GridBagLayout;
import java.awt.GridBagConstraints;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Form extends JFrame {

    private JLabel inputLabel;
    private JTextField inputNumbers;
    private JButton getResult;
    private JTextArea resultField;
    private JLabel answerLabel;
    private JTextField inputAnswer;
private JScrollPane resultFieldscrollVoc;
    //требуемый ответ
    private int ans;
    //исходные числа
    private int[] arr;

    public Form() {
        super("Расстановка знаков");
        this.setBounds(250,150,600,300);
        //Подготавливаем компоненты объекта
        inputLabel = new JLabel("Исходные числа:");
        getResult = new JButton("Получить результат");
        answerLabel = new JLabel("Требуемый ответ:");
        inputAnswer = new JTextField();
        resultField = new JTextArea();
        inputNumbers = new JTextField(10);
        resultFieldscrollVoc = new JScrollPane(resultField);
        resultFieldscrollVoc.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
        inputLabel.setHorizontalAlignment(JLabel.CENTER);
        answerLabel.setHorizontalAlignment(JLabel.CENTER);

        inputLabel.setFont(new Font("Arial", Font.BOLD, 16));
        answerLabel.setFont(new Font("Arial", Font.BOLD, 16));
        getResult.setFont(new Font("Arial", Font.BOLD, 16));
        inputAnswer.setFont(new Font("Arial", Font.BOLD, 16));
        inputNumbers.setFont(new Font("Arial", Font.BOLD, 16));
        resultField.setFont(new Font("Arial", Font.BOLD, 16));

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

        gbl.setConstraints(inputLabel, c);
        add(inputLabel);
        panel1.add(inputLabel);

        c.gridx = 2;
        c.gridy = 1;
        gbl.setConstraints(inputNumbers, c);
        panel1.add(inputNumbers);

        c.gridx = 1;
        c.gridy = 2;
        gbl.setConstraints(answerLabel, c);
        panel1.add(answerLabel);

        c.gridx = 2;
        c.gridy = 2;
        gbl.setConstraints(inputAnswer, c);
        panel1.add(inputAnswer);

        c.insets = new Insets(40, 0, 40, 0);
        c.gridx = 1;
        c.gridy = 3;
        c.fill   = GridBagConstraints.NONE;
        gbl.setConstraints(getResult, c);
        panel1.add(getResult);

        c.gridx = 2;
        c.gridy = 3;
        c.fill   = GridBagConstraints.HORIZONTAL;
        c.ipady = 50;
        gbl.setConstraints(resultFieldscrollVoc, c);
        panel1.add(resultFieldscrollVoc);

        resultField.setEditable(false);
        panel1.setBorder(BorderFactory.createEmptyBorder(30, 30, 30, 30));
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

