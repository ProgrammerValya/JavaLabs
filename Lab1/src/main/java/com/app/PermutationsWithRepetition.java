package main.java.com.app;
//класс, генерирующий все варианты перестановок

public class PermutationsWithRepetition {
    private char[] source;
    private int variationLength;

    public PermutationsWithRepetition(char[] source, int variationLength) {
        this.source = source;
        this.variationLength = variationLength;
    }

    public char[][] getVariations() {   //!!
        int srcLength = source.length; //количество символов из которых размещения
        int permutations = (int) Math.pow(srcLength, variationLength); //все варианты размещений

        char[][] table = new char[permutations][variationLength]; //двухмерный массив из всех вариантов

        for (int i = 0; i < variationLength; i++) {  // перебираем все позиции в комбинации
            int t2 = (int) Math.pow(srcLength, i);   // находим количество комбинаций начиная с заданной позиции
            for (int p1 = 0; p1 < permutations; ) {  //проходим по всем комбинациям
                for (int al = 0; al < srcLength; al++) {  // проходим по всем символам
                    for (int p2 = 0; p2 < t2; p2++) {  //частота записи каждого символа = количество комбинаций начиная с данной позиции
                        // в каждую комбинацию в опрделенную позицию записываем символ,
                        table[p1][i] = source[al];
                        p1++;
                }
                }
            }
        }
        return table;
    }
}