'''
Programa que debe recibir un archivo como entrada, analizarlo y devolver info.
por pantalla.

Entrada: Un archivo 'txt' con lineas en este formato
    [ID]=[Lista de numero separados por comas] [ORDENAR | BUSCAR] [argumentos]

Salida: Por consola en este formato
    identificador = [ID]
    Datos = [Array List]
    funciones = [lista de funciones]
    salida de la función = [SALIDA BUSCAR | ORDENAR]

Info: Si en una misma linea existen tanto la funcion buscar como ordenar, se
debe ejecutar la busqueda sobre los datos en bruto (sin ordenar).
    La funcion de busqueda debe mostrar todas las posiciones donde se encuentra
una coincidencia, en caso de no existir debe mostrar 'no encontrado'
'''

from tkinter import Tk
from tkinter.filedialog import askopenfilename
import re as regex


def open_file():
    Tk().withdraw()
    return askopenfilename()


def clear_ops(ops_list: list):
    ops_return = []
    op_regex = regex.compile('(BUSCAR|ORDENAR)(\s\d)?')
    for op in ops_list:
        if (type(op) is str) and (op != None) and (op != '\n') and (
                op != '') and (op != ' '):
            ops_return.append(op_regex.findall(op)[0])
    return ops_return


def execute_op(op: tuple, data: list):
    if op[0] == 'ORDENAR':
        data.sort()
        print('Datos ordenados: {}'.format(data))
    if op[0] == 'BUSCAR':
        if int(op[1]) in data:
            num_matches = data.count(int(op[1]))
            for i in range(len(data)):
                if data[i] == int(op[1]):
                    print('Encontrado {} en posición {}'.format(op[1], i))
            print('{} encontrado {} veces'.format(int(op[1]), num_matches))
        else:
            print('{} no encontrado'.format(int(op[1])))


def execute_ops(ops: list, data: list):
    list_ops = []
    for op in ops:
        if op[0] == 'ORDENAR':
            list_ops.append(op)
        if op[0] == 'BUSCAR':
            list_ops.insert(0, op)

    for op in list_ops:
        execute_op(op, data)


def read_file(filename: str):
    file_data = open(filename, 'r')
    file_rows = file_data.readlines()


def run():
    for row in file_rows:
        split_row = row.split('=', 1)
        print('Identificador: {}'.format(split_row.pop(0)))

        split_op = regex.split('(BUSCAR\s\d$)|(ORDENAR,?)', split_row[0])

        num_regex = regex.compile('\d+,?')
        clear_numbers = list(
            map(lambda string: int(string.strip(',')),
                num_regex.findall(split_op.pop(0))))

        print('Datos: {}'.format(clear_numbers))
        ops = clear_ops(split_op)
        execute_ops(ops, clear_numbers)
        print()


def view_menu():
    file_data = None
    print('1. Cargar archivo de entrada')
    print('2. Desplegar listas ordenadas')
    print('3. Desplegar listas ordenadas')
    print('4. Desplegar todo')
    print('5. Desplegar todas a archivo')
    print('6. Salir')
    opt = int(input('Ingrese una opción: '))
    print('')

    if opt == 1:
        filename = open_file()
    elif opt == 2:
        print('Opt 2')
    elif opt == 3:
        print('Opt 3')
    elif opt == 4:
        print('Opt 4')
    elif opt == 5:
        print('Opt 5')
    elif opt == 6:
        flag = False
        exit()
    else:
        print('¡Instrucción invalida!')
        view_menu()


if __name__ == '__main__':
    view_menu()
