package org.institutoserpis.ed;

public class Array {

	public static void main(String[] args) {
		
		
		int[] v = new int[]{5, 9, 7, 12, 21};
		


		for (int index=0; index < 5; index++)
	
		System.out.println("elemento con index= "+index + " vale " + v[index]);

	
		System.out.println("suma del array= " + suma(v));
		System.out.println("suma de otro array= " + suma(new int[]{14, 24}));
		System.out.println("suma de array vacio= " + suma(new int[]{}));
		
		
		System.out.println("el valor menor en V es: " + menor(v));
		
	}

	private static int suma(int[] v) { //SUMA
		// Numero de elementos del vector es: v.length
		int suma = 0;
		
		//for (int index=0; index < v.length; index++)
		//suma = suma + v[index];
		
		for(int item : v)
			suma = suma +item;
		return suma;
		}
	
	
	public static int menor(int[] v){
		//TODO IMPLREMENTAR
		//Devuelve el valor menor
		int menor = v[0];
		for (int index = 1; index < v.length ; index++)
			if(v[index]<menor){
				menor=v[index];
					
			}
		return menor;
		
	}
	
}
