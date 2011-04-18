/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package aplicaciondesguace;

import java.math.BigInteger;

/**
 *
 * @author damianmp
 */
public class RSA {

    private BigInteger key;
    private BigInteger N;

    public RSA(String k, String n){

        key = new BigInteger(k, 16);
        N = new BigInteger(n, 16);
    }

    public String encriptar(String s){

        int tam = 256;

        byte[] arraySinAmpliar = s.getBytes();
        int newTam = (int)Math.ceil((double)arraySinAmpliar.length/(double)tam)*tam;
        byte[] array = new byte[newTam];
        for(int i=0;i<arraySinAmpliar.length;i++){
            array[i] = arraySinAmpliar[i];
        }
        for(int i=arraySinAmpliar.length;i<newTam;i++){
            array[i]= (byte)' ';
        }

        for(int i=0;i<array.length/tam;i++){
            byte[] bloque = new byte[tam];
            for(int j=0;j<tam;j++){
                bloque[j]=array[tam*i+j];
            }
            BigInteger bi = new BigInteger(bloque);
            bi = bi.modPow(key,N);
            byte[] codificado = bi.toByteArray();
            System.out.println(codificado.length);
            for(int j=0;j<tam;j++){
                array[tam*i+j]=codificado[j];
            }
        }

        return array.toString();
    }

}
