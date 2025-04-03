Algoritmo Pseudocodigo_ECHO
	Escribir 'Cargando Pantalla...'
	Esperar 1.5 Segundos
	Limpiar Pantalla
	Definir recordatorio Como Cadena
	Definir opcion1, opcion2 Como Entero
	Repetir
		opcion1 <- 0
		Limpiar Pantalla
		Escribir 'Ventana de Inicio'
		Escribir ''
		Escribir '1. Agregar recordatorio'
		Escribir '2. Ver Recordatorio'
		Escribir '3. Salir'
		Leer opcion1
		Según opcion1 Hacer
			1:
				Limpiar Pantalla
				Repetir
					Escribir 'Ingrese un recordatorio'
					Leer recordatorio
					Si recordatorio='' Entonces
						Escribir 'No se puede dejar el recordatorio vacio vuelva a intentarlo'
						Escribir ''
						Esperar 3 Segundos
					FinSi
				Hasta Que recordatorio<>''
				Escribir 'Guardando el recordatorio...'
				Esperar 2 Segundos
				Limpiar Pantalla
				Escribir 'Recordatorio guardado'
				Esperar 2 Segundos
				Limpiar Pantalla
			2:
				Limpiar Pantalla
				Repetir
					Escribir 'Mostrando recordatorio'
					Escribir ''
					Escribir '1. Editar el recordatorio'
					Escribir '2. Borrar el recordatorio'
					Escribir '3. Ver el recordatorio'
					Escribir '4. Ir a Ventana de Inicio'
					Leer opcion2
					Según opcion2 Hacer
						1:
							Limpiar Pantalla
							Escribir 'Editar recordatorio'
							Esperar 1.5 Segundos
							Limpiar Pantalla
							Si recordatorio='' Entonces
								Escribir 'Recordatorio vacio'
								Escribir 'Precione cualquier tecla para seguir...'
								Esperar Tecla
								Limpiar Pantalla
							SiNo
								Repetir
									Escribir 'Ingrese el recordatorio'
									Leer recordatorio
									Si recordatorio='' Entonces
										Escribir 'No se puede dejar el recordatorio vacio vuelva a intentarlo'
										Escribir ''
										Esperar 3 Segundos
									FinSi
								Hasta Que recordatorio<>''
								Escribir 'Guardando el recordatorio...'
								Esperar 2 Segundos
								Limpiar Pantalla
								Escribir 'Recordatorio guardado'
								Esperar 2 Segundos
								Limpiar Pantalla
							FinSi
						2:
							Limpiar Pantalla
							Si recordatorio='' Entonces
								Escribir 'Recordatorio vacio'
								Escribir 'Precione cualquier tecla para seguir...'
								Esperar Tecla
								Limpiar Pantalla
							SiNo
								Escribir 'Borrando recordatorio'
								recordatorio <- ''
								Esperar 1 Segundos
								Limpiar Pantalla
								Escribir 'Recordatorio eliminado'
								Escribir 'Precione cualquier tecla para seguir...'
								Esperar Tecla
								Limpiar Pantalla
							FinSi
						3:
							Limpiar Pantalla
							Escribir 'Mostrando el recordatorio...'
							Esperar 1 Segundos
							Si recordatorio='' Entonces
								Escribir 'Recordatorio vacio'
								Escribir 'Precione cualquier tecla para seguir...'
								Esperar Tecla
								Limpiar Pantalla
							SiNo
								Escribir ''
								Escribir recordatorio
								Escribir ''
								Escribir 'Precione cualquier tecla para seguir...'
								Esperar Tecla
								Limpiar Pantalla
							FinSi
						De Otro Modo:
							Escribir 'Opción no encontrada'
					FinSegún
				Hasta Que opcion2=4
		FinSegún
	Hasta Que opcion1=3
	Escribir 'Saliendo del Programa...'
	Esperar 1.5 Segundos
	Limpiar Pantalla
FinAlgoritmo
